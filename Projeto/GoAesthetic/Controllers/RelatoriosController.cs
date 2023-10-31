using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class RelatoriosController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SideBar = true;
            return View();
        }
    }
}
