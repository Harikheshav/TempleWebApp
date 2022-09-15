using Microsoft.AspNetCore.Mvc;
using TempleWebApp.Models;

namespace TempleWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly TempleContext db;
        Admin admin;
        public AdminController(TempleContext db)
        {
            this.db = db;
        }
        public IActionResult login()
        {
            return View(admin);
        }
        [HttpPost]
        public IActionResult login(User l)
        {
            var result = (from i in db.Admins where l.Uname == i.Uname && l.Pword == i.Pword select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("UserName", result.Uname);
                return RedirectToAction("Index", "PoojaBkng");
            }
            else
                return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }

        public IActionResult register()
        {
            return View(admin);
        }
        [HttpPost]
        public IActionResult register(Admin admin)
        {
            db.Admins.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}

