using GoAesthetic.Controllers.ControllersBase;
using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoAesthetic.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(GoAestheticDbContext context) : base(false, context)
        {
        }

        public IActionResult Index()
        {
            ViewBag.SideBar = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuariosViewModel usuario)
        {
            var usuarioLogado = await Contexto.UsuariosViewModel.Where(x => x.Email == usuario.Email && x.Senha == usuario.Senha)
                                                          .AsNoTracking()
                                                          .Select(x => usuario.Id)                                                         
                                                          .FirstOrDefaultAsync();

            if (usuarioLogado == 0)
                return View("Index");
            
            RealizaLoginUsuario(usuarioLogado);

            return RedirectToAction("Index", "Home");
        }
    }
}
