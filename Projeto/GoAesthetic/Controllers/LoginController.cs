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
            var conexao = Contexto.Database.CanConnect();

            if (conexao)
                return View();
            else
                throw new Exception();
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
                                                                    NomeRole = u.Autorizacao.Role                                                        
                                                                })
                                                                .AsNoTracking()                                                     
                                                                .FirstOrDefaultAsync();

            if (usuarioLogado == null)
                return View("Index");
            
            RealizaLogInUsuario(usuarioLogado);

            return RedirectToAction("Index", "Home");
        } 
    }
}
