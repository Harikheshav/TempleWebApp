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
        public IActionResult Index()
        {
            return View(pooja);
        }
        public IActionResult Create()
        {
            return View(pooja);
        }
        [HttpPost]
        public IActionResult Create(Pooja pooja)
        {
            db.Poojas.Add(pooja);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            pooja = db.Poojas.Find(id);
            return View(pooja);
        }
        [HttpPost]
        public IActionResult Edit(Pooja newpooja)
        {
            int id = pooja.Pid;
            Pooja oldpooja = db.Poojas.Where(x => x.Pid == id).FirstOrDefault();
            db.Poojas.Remove(oldpooja);
            db.Poojas.Add(newpooja);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            db.Poojas.Remove(pooja);
            db.SaveChanges();
            return RedirectToAction("Index");
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
