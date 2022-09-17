using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TempleWebApp.Models;
namespace TempleWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly TempleContext db;
        User user = new User();
        public UserController(TempleContext db)
        {
            this.db = db;
        }

        public IActionResult login()
        {
            return View(user);
        }
        [HttpPost]
        public IActionResult login(User l)
        {
            var result = (from i in db.Users where l.Uname == i.Uname && l.Pword == i.Pword select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("UserName", result.Uname);
                HttpContext.Session.SetString("EmailId", result.Emailid);
                HttpContext.Session.SetString("UserId", result.Uid.ToString());
                return RedirectToAction("Index", "Userbook");
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
            return View(user);
        }
        [HttpPost]
        public IActionResult register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}

