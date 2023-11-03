using GoAesthetic.Controllers.ControllersBase;
using GoAesthetic.Respostas;
using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio.Implementacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class CadastroController : BaseController
    {
        public CadastroController(GoAestheticDbContext context) : base(false, context)
        {
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (VerificaUsuarioLogado())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Inclusao = true;
                return View();
            }
        }

        public async Task<IActionResult> Editar()
        {
            var loginNegocio = new LoginNegocio(Contexto);
            try
            {
                int idUsuarioLogado = BuscaIdUsuarioLogado();
                var usuario = await loginNegocio.BuscaUsuarioId(idUsuarioLogado);
                ViewBag.SideBar = true;
                ViewBag.Inclusao = false;
                return View("Index", usuario);
            }
            catch (Exception ex)
            {
                await ErroNegocio.EscreveErroBanco(ex);
                return RedirectToAction("Index", "Erro");
            }
        }

        [AllowAnonymous]
        [HttpPost("/Cadastro/RealizaCadastro")]
        public async Task<IActionResult> RealizaCadastro(UsuariosViewModel usuario)
        {
            var loginNegocio = new LoginNegocio(Contexto);
            var resposta = new RespostaPadrao();

            try
            {
                if (!ValidaUsuario(usuario, ref resposta, true))
                {
                    resposta.Sucesso = false;
                    return Json(resposta);
                }

                if(await loginNegocio.VerificaUsuarioExistente(usuario.Email))
                {
                    resposta.Sucesso = false;
                    resposta.Dados.Add(new Erros { Id = "Email", Erro = "Email já cadastrado" });
                    return Json(resposta);
                }

                var usuarioCadastrado = await loginNegocio.CadastraUsuario(usuario);
                RealizaLogInUsuario(usuarioCadastrado);
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
        

        [HttpPost("/Cadastro/AtualizaCadastro")]
        public async Task<IActionResult> AtualizaCadastro(UsuariosViewModel usuarioNovo)
        {
            var loginNegocio = new LoginNegocio(Contexto);
            var resposta = new RespostaPadrao();

            try
            {
                if (!ValidaUsuario(usuarioNovo, ref resposta, false))
                {
                    resposta.Sucesso = false;
                    return Json(resposta);                   
                }               

                int idUsuarioLogado = BuscaIdUsuarioLogado();
                var usuarioAntigo = await loginNegocio.BuscaUsuarioId(idUsuarioLogado);

                if(usuarioAntigo.Email != usuarioNovo.Email && await loginNegocio.VerificaUsuarioExistente(usuarioNovo.Email))
                {
                    resposta.Sucesso = false;
                    resposta.Dados.Add(new Erros { Id = "Email", Erro = "Email já cadastrado" });
                    return Json(resposta);
                }

                await loginNegocio.AtualizaUsuario(usuarioAntigo, usuarioNovo);
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

        private bool ValidaUsuario(UsuariosViewModel usuario, ref RespostaPadrao resposta, bool cadastro)
        {
            bool valida = true;

            if (string.IsNullOrEmpty(usuario.Nome))
            {
                resposta.Dados.Add(new Erros { Id = "Nome", Erro = "Digite um nome de usuário" });
                valida = false;
            }
            else if (usuario.Nome.Length < 5)
            {
                resposta.Dados.Add(new Erros { Id = "Nome", Erro = "Digite um nome com mais de 5 letras" });
                valida = false;
            }

            if (string.IsNullOrEmpty(usuario.Email))
            {
                resposta.Dados.Add(new Erros { Id = "Email", Erro = "Digite um e-mail" });
                valida = false;
            }
            else if (usuario.Email.Length < 10)
            {
                resposta.Dados.Add(new Erros { Id = "Email", Erro = "Digite um e-mail com mais de 10 letras" });
                valida = false;
            }
            else if (!usuario.Email.Contains('@'))
            {
                resposta.Dados.Add(new Erros { Id = "Email", Erro = "Digite um e-mail valido" });
                valida = false;
            }

            if (cadastro && string.IsNullOrEmpty(usuario.Senha))
            {
                resposta.Dados.Add(new Erros { Id = "Senha", Erro = "Digite uma senha" });
                valida = false;
            }
            else if (!string.IsNullOrEmpty(usuario.Senha) && usuario.Senha.Length < 5)
            {
                resposta.Dados.Add(new Erros { Id = "Senha", Erro = "Digite uma senha com mais de 5 letras" });
                valida = false;
            }

            if (usuario.DataNascimento > DateTime.Now || usuario.DataNascimento < DateTime.Now.AddYears(-100))
            {
                resposta.Dados.Add(new Erros { Id = "DataNascimento", Erro = "Digite uma data de nascimento valida" });
                valida = false;
            }

            if (!usuario.Altura.HasValue)
            {
                resposta.Dados.Add(new Erros { Id = "Altura", Erro = "Digite uma altura" });
                valida = false;
            }
            else if (usuario.Altura.Value > 300 || usuario.Altura.Value < 50)
            {
                resposta.Dados.Add(new Erros { Id = "Altura", Erro = "Digite uma altura valida" });
                valida = false;
            }

            if (!usuario.Peso.HasValue)
            {
                resposta.Dados.Add(new Erros { Id = "Peso", Erro = "Digite um peso" });
                valida = false;
            }
            else if (usuario.Peso.Value > 300 || usuario.Peso.Value < 20)
            {
                resposta.Dados.Add(new Erros { Id = "Peso", Erro = "Digite um peso valido" });
                valida = false;
            }

            return valida;
        }
    }
}

