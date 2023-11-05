using GoAesthetic.Controllers.ControllersBase;
using GoAesthetic.Respostas;
using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio.Helpers;
using GoAestheticNegocio.Implementacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoAesthetic.Controllers
{
    public class MarcosEvolucaoController : BaseController
    {
        public MarcosEvolucaoController(GoAestheticDbContext context) : base(context)
        {
        }

        public IActionResult CadastroMarco()
        {       
            return View();
        }

        public async Task<IActionResult> Galeria()
        {
            var marcosNegocio = new MarcosEvolucaoNegocio(Contexto);

            try
            {
                int idUsuarioLogado = BuscaIdUsuarioLogado();
                var listaMarcos = await marcosNegocio.BuscarMarcosComFotos(idUsuarioLogado);
                return View(listaMarcos);
            }
            catch (Exception ex)
            {
                await ErroNegocio.EscreveErroBanco(ex);
                return RedirectToAction("ErroGenerico", "Erro");
            }

        }



        [HttpPost("/MarcosEvolucao/CadastraMarco")]
        public async Task<IActionResult> CadastraMarco(MarcosEvolucaoViewModel marcosEvolucao)
        {
            var marcoEvolucaoNegocio = new MarcosEvolucaoNegocio(Contexto);
            var resposta = new RespostaPadrao();

            try
            {
                if (!ValidaMarcoEvolucao(marcosEvolucao, ref resposta))
                {
                    resposta.Sucesso = false;
                    return Json(resposta);
                }

                await marcoEvolucaoNegocio.CadastraMarcoEvolucao(marcosEvolucao, BuscaIdUsuarioLogado());
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


        public bool ValidaMarcoEvolucao(MarcosEvolucaoViewModel marcosEvolucao, ref RespostaPadrao resposta)
        {
            bool valida = true;

            if (marcosEvolucao.Altura == 0)
            {
                resposta.Dados.Add(new Erros { Id = "Altura", Erro = "Digite uma altura" });
                valida = false;
            }
            else if (marcosEvolucao.Altura > 300 || marcosEvolucao.Altura < 50)
            {
                resposta.Dados.Add(new Erros { Id = "Altura", Erro = "Digite uma altura valida" });
                valida = false;
            }

            if (marcosEvolucao.Peso == 0)
            {
                resposta.Dados.Add(new Erros { Id = "Peso", Erro = "Digite um peso" });
                valida = false;
            }
            else if (marcosEvolucao.Peso > 300 || marcosEvolucao.Peso < 20)
            {
                resposta.Dados.Add(new Erros { Id = "Peso", Erro = "Digite um peso valido" });
                valida = false;
            }

            var extensoesValidas = new string[] { "png", "jpg", "jpeg" };
            if (marcosEvolucao.Arquivo != null && marcosEvolucao.Arquivo.Length > 1000000) //valor em mb
            {
                resposta.Dados.Add(new Erros { Id = "Arquivo", Erro = "Tamanho máximo permitido: 1Mb" });
                valida = false;
            }
            else if (marcosEvolucao.Arquivo != null && extensoesValidas.Contains(Path.GetExtension(marcosEvolucao.Arquivo.FileName).ToLower()))
            {
                resposta.Dados.Add(new Erros { Id = "Arquivo", Erro = "Extensão não permitida" });
                valida = false;
            }

            return valida;
        }
    }
}
