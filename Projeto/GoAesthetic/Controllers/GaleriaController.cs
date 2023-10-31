using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class GaleriaController : Controller 
    {
        public IActionResult Index()
        {
            ViewBag.SideBar = true;
            return View();
        }
    }
}
