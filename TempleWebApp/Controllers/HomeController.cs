using Microsoft.AspNetCore.Mvc;

namespace TempleWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
