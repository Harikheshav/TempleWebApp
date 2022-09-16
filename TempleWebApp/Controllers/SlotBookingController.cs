using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempleWebApp.Models;
namespace TempleWebApp.Controllers
{
    public class SlotBookingController : Controller
    {
        SlotBkng slot = new SlotBkng();
        TempleContext db;

        public SlotBookingController(TempleContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(slot);
        }
        [HttpPost]
        public IActionResult Index(SlotBkng slot)
        {
            if (slot.SlotName=="FunctionHall")
            {
                FnHallBkng fn = new FnHallBkng(slot);
                db.FnHallBkngs.Add(fn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (slot.SlotName == "ConcertHall")
            {
                ConHallBkng con = new ConHallBkng(slot);
                db.ConHallBkngs.Add(con);
                db.SaveChanges();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (slot.SlotName == "Annadhanam")
            {
                AnDhanBkng anad = new AnDhanBkng(slot);
                db.AnDhanBkngs.Add(anad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}
