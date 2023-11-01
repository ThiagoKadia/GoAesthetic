using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class AcessoNegadoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SideBar = false;
            return View();
        }
    }
}
