using Microsoft.AspNetCore.Mvc;
using TempleWebApp.Models;

namespace TempleWebApp.Controllers
{
    public class PoojaController : Controller
    {
        private readonly TempleContext db;
        Pooja pooja;
        public PoojaController(TempleContext _db)
        {
            db = _db;
        }
        public IActionResult Create()
        {
            return View(pooja);
        }
        [HttpPost]
        public IActionResult Create(Pooja pooja)
        {
            if (ModelState.IsValid)
            {
                db.Poojas.Add(pooja);
                db.SaveChanges();
            }
            else
            {
                return View(pooja);
            }
            return RedirectToAction("Details");
        }
        public IActionResult Edit(int id)
        {
            pooja = db.Poojas.Find(id);
            return View(pooja);
        }
        [HttpPost]
        public IActionResult Edit(Pooja newpooja)
        {
            int id = newpooja.Pid;
            Pooja oldpooja = db.Poojas.Where(x => x.Pid == id).FirstOrDefault();
            db.Poojas.Remove(oldpooja);
            if (ModelState.IsValid)
            {
                db.Poojas.Add(newpooja);
                db.SaveChanges();
            }
            return RedirectToAction("Details");
        }
        public IActionResult Delete(int id)
        {
            pooja = db.Poojas.Where(x => x.Pid == id).FirstOrDefault();
            return View(pooja);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            pooja = db.Poojas.Find(id);
            try
            {
                db.Poojas.Remove(pooja);
                db.SaveChanges();
            }
            catch
            {
                TempData["Message"] = "Unable to delete because already a " + pooja.Name + " has been set by User";
            }
            return RedirectToAction("Details");
        }
        public IActionResult Detail(int id)
        {
            pooja = db.Poojas.Where(pj => pj.Pid == id).Select(pj => pj).SingleOrDefault();
            return View(pooja);
        }
        public IActionResult Details()
        {
            return View(db.Poojas);
        }
    }
}
