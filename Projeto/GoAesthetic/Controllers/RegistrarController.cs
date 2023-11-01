using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class RegistrarController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SideBar = true;
            return View();
        }

    }
}
