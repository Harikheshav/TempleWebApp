using Microsoft.AspNetCore.Mvc;
using TempleWebApp.Models;

namespace TempleWebApp.Controllers
{
    public class ConHallBkngController : Controller
    {
        private readonly TempleContext db;
        ConHallBkng cbkng;
        public ConHallBkngController(TempleContext _db)
        {
            db = _db;
        }
        public IActionResult Edit(int id)
        {
            cbkng = db.ConHallBkngs.Find(id);
            return View(cbkng);
        }
        private string DateValidation(DateTime? sdt, DateTime? edt)
        {
            if (sdt <= DateTime.Now)
            {
                return "Cannot Assign Events on Past Date and Time";
            }
            if (edt <= sdt)
            {
                return "Event ends before it gets started";
            }
            else
                return null;

        }
        [HttpPost]
        public IActionResult Edit(ConHallBkng newcbkng)
        {
            int id = newcbkng.Bkid;
            ConHallBkng oldcbkng = db.ConHallBkngs.Where(x => x.Bkid == id).FirstOrDefault();
            db.ConHallBkngs.Remove(oldcbkng);
            string valid = DateValidation(newcbkng.Sdt, newcbkng.Edt);
            if (valid != null)
            {
                ModelState.AddModelError("Error", valid);
                return View(cbkng);
            }
            else
            {
                db.ConHallBkngs.Add(newcbkng);
                db.SaveChanges();
            }   
            return RedirectToAction("Index", "AdminBook");

        }
        public IActionResult Delete(int id)
        {
            cbkng = db.ConHallBkngs.Where(x => x.Bkid == id).FirstOrDefault();
            return View(cbkng);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            cbkng = db.ConHallBkngs.Find(id);
            db.ConHallBkngs.Remove(cbkng);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminBook");
        }
    }

}
