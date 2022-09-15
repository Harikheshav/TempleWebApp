using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TempleWebApp.Models;

namespace TempleWebApp.Controllers
{
    public class PoojaBkngController : Controller
    {
        PoojaBkng pooja; 
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
            db.PoojaBkngs.Add(pooja);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
