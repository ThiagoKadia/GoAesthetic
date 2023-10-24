using GoAestheticEntidades;
using GoAestheticNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoAesthetic.Controllers.ControllersBase
{
    public class BaseController : Controller
    {
        protected GoAestheticDbContext Contexto;
        protected int IdUsuarioLogado { get; set; }
        private bool SideBar { get; set; }
        public BaseController(GoAestheticDbContext context)
        {
            SideBar = true;
            Contexto = context;
        }

        public BaseController(bool sideBar, GoAestheticDbContext context)
        {
            SideBar = sideBar;
            Contexto = context;
        }

        protected bool VerificaUsuarioLogado()
        {
            bool estaLogado = HttpContext.Session.TryGetValue(Constantes.ChaveSessionUsuario, out byte[]? usuario);

            if (estaLogado)
                IdUsuarioLogado =  BitConverter.ToInt32(usuario);

            return estaLogado;
        }

        protected void RealizaLoginUsuario(int idUsuario)
        {
            HttpContext.Session.Set(Constantes.ChaveSessionUsuario, BitConverter.GetBytes(idUsuario));
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.SideBar = SideBar;

            base.OnActionExecuting(filterContext);
        }
    }
}
