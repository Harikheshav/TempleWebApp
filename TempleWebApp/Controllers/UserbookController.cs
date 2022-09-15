using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TempleWebApp.Models;

namespace TempleWebApp.Controllers
{
    public class UserbookController : Controller
    {
        UserBook userBook = new UserBook();
        TempleContext db;
        public UserbookController(TempleContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            userBook.ConHallBkngs = db.ConHallBkngs.ToList();
            userBook.FnHallBkngs = db.FnHallBkngs.ToList();
            userBook.AnDhanBkngs = db.AnDhanBkngs.ToList();
            userBook.PoojaBkngs = db.PoojaBkngs.Include(x=>x.Poo).ToList();
            return View(userBook);
        }
        public IActionResult AddUser(int ch,int id)
        //Save and store database as class
        {
            if (ch == 1)
            {
                ConHallBkng conBkng = db.ConHallBkngs.Find(id);
                db.ConHallBkngs.Remove(conBkng);
                conBkng.User = db.Users.Find(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                db.ConHallBkngs.Add(conBkng);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (ch == 2)
            {
                FnHallBkng fnBkng = db.FnHallBkngs.Find(id);
                db.FnHallBkngs.Remove(fnBkng);
                fnBkng.User = db.Users.Find(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                db.FnHallBkngs.Add(fnBkng);
                return RedirectToAction("Index");
            }
            else if (ch == 3)
            {
                PoojaBkng pbkng = db.PoojaBkngs.Find(id);
                pbkng.User = db.Users.Find(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                db.PoojaBkngs.Add(pbkng);
                return RedirectToAction("Index");
            }
            else if (ch == 4)
            {
                AnDhanBkng abkng = db.AnDhanBkngs.Find(id);
                AnDhanBkng.User = db.Users.Find(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                db.AnDhanBkngs.Add(abkng);
                return RedirectToAction("Index");
            }
            else
                return new EmptyResult();
        }
    }
}
