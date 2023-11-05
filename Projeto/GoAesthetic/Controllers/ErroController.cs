using GoAesthetic.Controllers.ControllersBase;
using GoAestheticEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class ErroController : BaseController
    {
        public ErroController(GoAestheticDbContext context) : base(false, context)
        {
        }

        [AllowAnonymous]
        public IActionResult ErroGenerico()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}
