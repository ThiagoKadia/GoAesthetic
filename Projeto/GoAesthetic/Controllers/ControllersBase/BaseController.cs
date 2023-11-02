using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio;
using GoAestheticNegocio.Implementacao;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace GoAesthetic.Controllers.ControllersBase
{
    [Authorize(Policy = "RequirimentoMinimoAcesso")]
    public class BaseController : Controller
    {
        protected GoAestheticDbContext Contexto;
        private bool SideBar { get; set; }

        protected ErroNegocio ErroNegocio;
        public BaseController(GoAestheticDbContext context)
        {
            SideBar = true;
            Contexto = context;
            ErroNegocio = new ErroNegocio(context);
        }

        public BaseController(bool sideBar, GoAestheticDbContext context)
        {
            SideBar = sideBar;
            Contexto = context;
            ErroNegocio = new ErroNegocio(context);
        }

        protected async void RealizaLogInUsuario(UsuariosViewModel Usuario)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, Usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, Usuario.Nome),
                new Claim(ClaimTypes.Role, Usuario.NomeRole),
                new Claim("GoAesthetic", "Code")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties()
                {
                    IsPersistent = true,
                });
        }

        protected bool VerificaUsuarioLogado()
        {
            if (HttpContext.User.Identity == null)
                return false;

            return HttpContext.User.Identity.IsAuthenticated;
        }

        protected async void RealizaLogOutUsuario()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.SideBar = SideBar;

            base.OnActionExecuting(filterContext);
        }
    }
}
