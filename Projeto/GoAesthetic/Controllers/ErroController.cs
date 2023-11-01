using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class ErroController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SideBar = false;
            return View();
        }
    }
}
