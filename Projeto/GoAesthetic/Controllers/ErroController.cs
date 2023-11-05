using GoAesthetic.Controllers.ControllersBase;
using GoAestheticEntidades;
using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class ErroController : BaseController
    {
        public ErroController(GoAestheticDbContext context) : base(false, context)
        {
        }

        public IActionResult ErroGenerico()
        {
            return View();
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}
