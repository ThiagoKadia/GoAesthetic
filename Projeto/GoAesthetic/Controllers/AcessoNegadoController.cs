using GoAesthetic.Controllers.ControllersBase;
using GoAestheticEntidades;
using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class AcessoNegadoController : BaseController
    {
        public AcessoNegadoController(GoAestheticDbContext context) : base(false, context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
