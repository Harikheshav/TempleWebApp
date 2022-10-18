using Microsoft.AspNetCore.Mvc;
using TempleWebApp.Models;

namespace TempleWebApp.Controllers
{
    public class AnDhanBkngController : Controller
    {
        private readonly TempleContext db;
        AnDhanBkng abkng;
        public AnDhanBkngController(TempleContext _db)
        {
            db = _db;
        }
        public IActionResult Edit(int id)
        {
            abkng = db.AnDhanBkngs.Find(id);
            return View(abkng);
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
        public IActionResult Edit(AnDhanBkng newabkng)
        {
            int id = newabkng.Bkid;
            AnDhanBkng oldabkng = db.AnDhanBkngs.Where(x => x.Bkid == id).FirstOrDefault();
            db.AnDhanBkngs.Remove(oldabkng);
            string valid = DateValidation(newabkng.Sdt, newabkng.Edt);
            if (valid != null)
            {
                ModelState.AddModelError("Error", valid);
                return View(abkng);
            }
            else
            {
                db.AnDhanBkngs.Add(newabkng);
                db.SaveChanges();
                return RedirectToAction("Index", "AdminBook");
            }

        }
        public IActionResult Delete(int id)
        {
            abkng = db.AnDhanBkngs.Where(x => x.Bkid == id).FirstOrDefault();
            return View(abkng);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            abkng = db.AnDhanBkngs.Find(id);
            db.AnDhanBkngs.Remove(abkng);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminBook");
        }

    }
}
