using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SideBar = true;
            return View();
        }
    }
}
