using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TempleWebApp.Models;

namespace TempleWebApp.Controllers
{
    public class PoojaBkngController : Controller
    {
        PoojaBkng pooja = new PoojaBkng(); 
        TempleContext db;
        public PoojaBkngController(TempleContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var result = db.PoojaBkngs.Include(poobk => poobk.Poo);
            var res = db.Poojas.ToList();
            ViewBag.Pooid = new SelectList(res, "Pid", "Name");
            return View(pooja);
        }
        [HttpPost]
        public IActionResult Index(PoojaBkng pooja)
        {
            if (ModelState.IsValid)
            {
                db.PoojaBkngs.Add(pooja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(pooja);
            }
        }
        public IActionResult Edit(int id)
        {
            pooja = db.PoojaBkngs.Find(id);
            var res = db.Poojas.ToList();
            ViewBag.Pooid = new SelectList(res, "Pid", "Name");
            return View(pooja);
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
        public IActionResult Edit(PoojaBkng newpooja)
        {
            int id = newpooja.Bkid;
            PoojaBkng oldpooja = db.PoojaBkngs.Where(x => x.Bkid == id).FirstOrDefault();
            db.PoojaBkngs.Remove(oldpooja);
            string valid = DateValidation(newpooja.Sdt, newpooja.Edt);
            if (valid != null)
            {
                ModelState.AddModelError("Error", valid);
                return View(newpooja);
            }
            else
            {
                db.PoojaBkngs.Add(newpooja);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "AdminBook");

        }
        public IActionResult Delete(int id)
        {
            pooja = db.PoojaBkngs.Where(x => x.Bkid == id).FirstOrDefault();
            return View(pooja);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            pooja = db.PoojaBkngs.Find(id);
            db.PoojaBkngs.Remove(pooja);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminBook");
        }
    }
}
