using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using TempleWebApp.Models;

namespace TempleWebApp.Controllers
{
    public class UserbookController : Microsoft.AspNetCore.Mvc.Controller
    {
        UserBook userBook = new UserBook();
        TempleContext db;
        public UserbookController(TempleContext _db)
        {
            db = _db;
        }
        //Displays events not booked by any users.
        public IActionResult Index()
        {
            userBook.ConHallBkngs = db.ConHallBkngs.Where(x=>x.Userid==null).ToList();
            userBook.FnHallBkngs = db.FnHallBkngs.Where(x => x.Userid == null).ToList();
            userBook.AnDhanBkngs = db.AnDhanBkngs.Where(x => x.Userid == null).ToList();
            userBook.PoojaBkngs = db.PoojaBkngs.Where(x => x.Userid == null).Include(x=>x.Poo).ToList();
            return View(userBook);
        }
        public IActionResult AddUser(int ch, int id)
        //Add's a user to a unassigned booking
        {
            if (ch == 1)
            {
                PoojaBkng pbkng = db.PoojaBkngs.Find(id);
                pbkng.User = db.Users.Find(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                db.PoojaBkngs.Update(pbkng);
                db.SaveChanges();
                return RedirectToAction("UserBooking");
            }
            else if (ch == 2)
            {
                AnDhanBkng abkng = db.AnDhanBkngs.Find(id);
                abkng.User = db.Users.Find(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                db.AnDhanBkngs.Update(abkng);
                db.SaveChanges();
                return RedirectToAction("UserBooking");
            }
            else if (ch == 3)
            {
                ConHallBkng conBkng = db.ConHallBkngs.Find(id);
                conBkng.User = db.Users.Find(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                db.ConHallBkngs.Update(conBkng);
                db.SaveChanges();
                return RedirectToAction("UserBooking");

            }
            else if (ch == 4)
            {
                FnHallBkng fnBkng = db.FnHallBkngs.Find(id);
                fnBkng.User = db.Users.Find(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                db.FnHallBkngs.Update(fnBkng);
                db.SaveChanges();
                return RedirectToAction("UserBooking");
            }
            else
                return new Microsoft.AspNetCore.Mvc.EmptyResult();
        }

        //Display events assigned to the respective user and gives options for generating bank challan, emailing it.
        public IActionResult UserBooking()
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.uname = HttpContext.Session.GetString("UserName");
            userBook.ConHallBkngs = db.ConHallBkngs.Where(x => x.Userid == userid).ToList();
            userBook.FnHallBkngs = db.FnHallBkngs.Where(x => x.Userid == userid).ToList();
            userBook.AnDhanBkngs = db.AnDhanBkngs.Where(x => x.Userid == userid).ToList();
            userBook.PoojaBkngs = db.PoojaBkngs.Where(x => x.Userid == userid).Include(x => x.Poo).ToList();
            return View(userBook);
        }
        public IActionResult CancelBooking(int ch, int id)
        {
                if (ch == 1)
                {
                    PoojaBkng pbkng = db.PoojaBkngs.Find(id);
                    pbkng.Userid = null;
                    pbkng.User = null;
                    db.PoojaBkngs.Update(pbkng);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if (ch == 2)
                {
                    AnDhanBkng abkng = db.AnDhanBkngs.Find(id);
                    abkng.Userid = null;
                    abkng.User = null;
                    db.AnDhanBkngs.Update(abkng);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if (ch == 3)
                {
                    ConHallBkng conBkng = db.ConHallBkngs.Find(id);
                    conBkng.Userid = null;
                    conBkng.User = null;
                    db.ConHallBkngs.Update(conBkng);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else if (ch == 4)
                {
                    FnHallBkng fnBkng = db.FnHallBkngs.Find(id);
                    fnBkng.Userid = null;
                    fnBkng.User = null;
                    db.FnHallBkngs.Update(fnBkng);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return new Microsoft.AspNetCore.Mvc.EmptyResult();
        }
            public IActionResult GenerateChallan(int ch,int id)
            {
            ViewBag.User = HttpContext.Session.GetString("UserName");
            if (ch == 1)
            {
                PoojaBkng pbkng = db.PoojaBkngs.Include(x => x.Poo).Where(x => x.Bkid == id).Select(x => x).SingleOrDefault();
                if (pbkng != null)
                {
                    TempData["Booking_Type"] = "Pooja";
                    ViewBag.Details = pbkng.Poo.Name;
                    ViewBag.StartDate = pbkng.Sdt;
                    ViewBag.EndDate = pbkng.Edt;
                    ViewBag.Cost = pbkng.Poo.Cost;
                }
                return View();
            }
            else if (ch == 2)
            {
                AnDhanBkng abkng = db.AnDhanBkngs.Find(id);
                if (abkng != null)
                {
                    TempData["Booking_Type"] = "Annadhanam";
                    ViewBag.Details = abkng.Det;
                    ViewBag.StartDate = abkng.Sdt;
                    ViewBag.EndDate = abkng.Edt;
                    ViewBag.Cost = abkng.Cost;
                }
                return View();
            }
            else if (ch == 3)
            {
                ConHallBkng conBkng = db.ConHallBkngs.Find(id);
                if (conBkng != null)
                {
                    TempData["Booking_Type"] = "Concert Hall";
                    ViewBag.Details = conBkng.Det;
                    ViewBag.StartDate = conBkng.Sdt;
                    ViewBag.EndDate = conBkng.Edt;
                    ViewBag.Cost = conBkng.Cost;
                }
                return View();
            }
            else if (ch == 4)
            {
                FnHallBkng fnBkng = db.FnHallBkngs.Find(id);
                if(fnBkng != null)
                {
                TempData["Booking_Type"] = "Function Hall";
                ViewBag.Details = fnBkng.Det;
                ViewBag.StartDate = fnBkng.Sdt;
                ViewBag.EndDate = fnBkng.Edt;
                ViewBag.Cost = fnBkng.Cost;
                }
                return View();
            }
            else
                return new Microsoft.AspNetCore.Mvc.EmptyResult();
    }
        public static string RenderViewToString(string viewName, object model, System.Web.Mvc.ControllerContext context)
        {
            context.Controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                var viewContext = new ViewContext(context, viewResult.View, context.Controller.ViewData, context.Controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
