using GoAesthetic.Controllers.ControllersBase;
using GoAesthetic.Respostas;
using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio.Implementacao;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoAesthetic.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseController
    {    
        public LoginController(GoAestheticDbContext context) : base(false, context)
        {
        }


        public IActionResult Index()
        {
            if(VerificaUsuarioLogado())
                return RedirectToAction("Index", "Home");
            else
                return View();
        }

        [HttpPost("/Login/RealizaLogin")]
        public async Task<IActionResult> RealizaLogin(UsuariosViewModel usuario)
        {
            var loginNegocio = new LoginNegocio(Contexto);
            var resposta = new RespostaPadrao();

            try
            {
                var usuarioLogado = await loginNegocio.VerificaLoginCorreto(usuario.Email, usuario.Senha);

                if (usuarioLogado == null)
                {
                    resposta.Sucesso = false;
                    resposta.Mensagem = "Usuário ou Senha Inexistestes";
                    return Json(resposta);
                }

                RealizaLogInUsuario(usuarioLogado);

                resposta.Sucesso = true;
            }
            catch (Exception ex)
            {
                resposta.Erro = true;
                resposta.Mensagem = ex.Message;
                await ErroNegocio.EscreveErroBanco(ex);
            }

            return Json(resposta);
        }
    }
}
