using GoAesthetic.Controllers.ControllersBase;
using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoAesthetic.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(GoAestheticDbContext context) : base(false, context)
        {
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.SideBar = false;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(UsuariosViewModel usuario)
        {
            var usuarioLogado = await Contexto.UsuariosViewModel.Where(x => x.Email == usuario.Email && x.Senha == usuario.Senha)
                                                          .Select(u => new UsuariosViewModel()
                                                          {
                                                              Nome = u.Nome,
                                                              Senha = u.Senha,
                                                              NomeRole = u.Role.Nome                                                        
                                                          })
                                                          .AsNoTracking()                                                     
                                                          .FirstOrDefaultAsync();

            if (usuarioLogado == null)
                return View("Index");
            
            RealizaLoginUsuario(usuarioLogado);

            return RedirectToAction("Index", "Home");
        } 
    }
}
