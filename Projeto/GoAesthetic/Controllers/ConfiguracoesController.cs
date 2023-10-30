using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class ConfiguracoesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SideBar = true;
            return View();
        }
    }
}
