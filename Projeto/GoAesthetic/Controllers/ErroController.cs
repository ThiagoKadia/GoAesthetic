using GoAesthetic.Controllers.ControllersBase;
using GoAestheticEntidades;
using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class ErroController : BaseController
    {
        public ErroController(bool sideBar, GoAestheticDbContext context) : base(false, context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
