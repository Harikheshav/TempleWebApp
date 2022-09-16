using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using TempleWebApp.Models;

namespace TempleWebApp.Controllers
{
    public class AdminBookController : Microsoft.AspNetCore.Mvc.Controller
    {
        UserBook userBook = new UserBook();
        TempleContext db;
        public AdminBookController(TempleContext _db)
        {
            db = _db;
        }
        //Displays events not booked by any users.
        public IActionResult Index()
        {
            userBook.ConHallBkngs = db.ConHallBkngs.Include(x => x.User).ToList();
            userBook.FnHallBkngs = db.FnHallBkngs.Include(x => x.User).ToList();
            userBook.AnDhanBkngs = db.AnDhanBkngs.Include(x => x.User).ToList();
            userBook.PoojaBkngs = db.PoojaBkngs.Include(x => x.User).Include(x=>x.Poo).ToList();
            return View(userBook);
        }
        public IActionResult GenerateBill(int ch,int id)
        {
            ViewBag.Admin = HttpContext.Session.GetString("AdminName");
            if (ch == 1)
            {
                PoojaBkng pbkng = db.PoojaBkngs.Include(x => x.User).Include(x => x.Poo).Where(x=>x.Bkid==id).Select(x=>x).SingleOrDefault();
                if (pbkng != null)
                {
                    TempData["Booking_Type"] = "Pooja";
                    ViewBag.Details = pbkng.Poo.Name;
                    ViewBag.StartDate = pbkng.Sdt;
                    ViewBag.EndDate = pbkng.Edt;
                    ViewBag.Cost = pbkng.Poo.Cost;
                    ViewBag.User = pbkng.User.Uname;
                }
                return View();
            }
            else if (ch == 2)
            {
                AnDhanBkng abkng = db.AnDhanBkngs.Include(x => x.User).Where(x=>x.Bkid==id).Select(x=>x).SingleOrDefault();
                if (abkng != null)
                {
                    TempData["Booking_Type"] = "Annadhanam";
                    ViewBag.Details = abkng.Det;
                    ViewBag.StartDate = abkng.Sdt;
                    ViewBag.EndDate = abkng.Edt;
                    ViewBag.Cost = abkng.Cost;
                    ViewBag.User = abkng.User.Uname;
                }
                return View();
            }
            else if (ch == 3)
            {
                ConHallBkng conBkng = db.ConHallBkngs.Include(x => x.User).Where(x => x.Bkid == id).Select(x => x).SingleOrDefault();
                if (conBkng != null)
                {
                    TempData["Booking_Type"] = "Concert Hall";
                    ViewBag.Details = conBkng.Det;
                    ViewBag.StartDate = conBkng.Sdt;
                    ViewBag.EndDate = conBkng.Edt;
                    ViewBag.Cost = conBkng.Cost;
                    ViewBag.User = conBkng.User.Uname;
                }
                return View();
            }
            else if (ch == 4)
            {
                FnHallBkng fnBkng = db.FnHallBkngs.Include(x => x.User).Where(x => x.Bkid == id).Select(x => x).SingleOrDefault();
                if(fnBkng != null)
                {
                TempData["Booking_Type"] = "Function Hall";
                ViewBag.Details = fnBkng.Det;
                ViewBag.StartDate = fnBkng.Sdt;
                ViewBag.EndDate = fnBkng.Edt;
                ViewBag.Cost = fnBkng.Cost;
                ViewBag.User = fnBkng.User.Uname;
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
