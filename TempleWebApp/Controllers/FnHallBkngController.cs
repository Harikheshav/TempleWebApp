using Microsoft.AspNetCore.Mvc;
using TempleWebApp.Models;

namespace TempleWebApp.Controllers
{
    public class FnHallBkngController : Controller
    {
        private readonly TempleContext db;
        FnHallBkng fbkng;
        public FnHallBkngController(TempleContext _db)
        {
            db = _db;
        }
        public IActionResult Edit(int id)
        {
            fbkng = db.FnHallBkngs.Find(id);
            return View(fbkng);
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
        public IActionResult Edit(FnHallBkng newfbkng)
        {
            int id = newfbkng.Bkid;
            FnHallBkng oldfbkng = db.FnHallBkngs.Where(x => x.Bkid == id).FirstOrDefault();
            db.FnHallBkngs.Remove(oldfbkng);
            string valid = DateValidation(newfbkng.Sdt, newfbkng.Edt);
            if (valid != null)
            {
                ModelState.AddModelError("Error", valid);
                return View(newfbkng);
            }
            else
            {
                db.FnHallBkngs.Add(newfbkng);
                db.SaveChanges();
                return RedirectToAction("Index", "AdminBook");
            }

        }
        public IActionResult Delete(int id)
        {
            fbkng = db.FnHallBkngs.Where(x => x.Bkid == id).FirstOrDefault();
            return View(fbkng);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            fbkng = db.FnHallBkngs.Find(id);
            db.FnHallBkngs.Remove(fbkng);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminBook");
        }
    }
}
