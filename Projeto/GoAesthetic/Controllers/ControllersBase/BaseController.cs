using GoAestheticEntidades;
using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers.ControllersBase
{
    public class BaseController : Controller
    {
        protected GoAestheticDbContext contexto = new GoAestheticDbContext();
        public BaseController()
        {
            contexto.Database.EnsureCreated();
        }
    }
}
