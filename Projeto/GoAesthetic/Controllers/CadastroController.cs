using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SideBar = false;
            return View();
        }
    }
}

