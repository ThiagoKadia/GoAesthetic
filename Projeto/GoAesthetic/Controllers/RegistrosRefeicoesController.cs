using GoAesthetic.Controllers.ControllersBase;
using GoAesthetic.Respostas;
using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio.Implementacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GoAesthetic.Controllers
{
    public class RegistrosRefeicoesController : BaseController
    {
        public RegistrosRefeicoesController(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task<IActionResult> RegistrarRefeicao()
        {
            try
            {
                var alimentos = await Contexto.InformacoesAlimentosViewModel.Select(x => new { Id = x.Id, Value = x.Nome })
                                                                        .AsNoTracking()
                                                                        .ToListAsync();

                List<SelectListItem> itens = new List<SelectListItem>();
                foreach (var alimento in alimentos)
                {
                    itens.Add(new SelectListItem { Value = alimento.Id.ToString(), Text = alimento.Value });
                }

                ViewBag.Alimentos = new SelectList(itens, "Value", "Text");
            }
            catch(Exception ex)
            {
                await ErroNegocio.EscreveErroBanco(ex);
                return RedirectToAction("ErroGenerico", "Erro");
            }
            

            return View();
        }

        public async Task<IActionResult> Historico()
        {
            var alimentoNegocio = new AlimentosNegocio(Contexto);

            try
            {
                var listaRefeicoes = await alimentoNegocio.BuscaListaRefeicoesUsuario(BuscaIdUsuarioLogado());
                return View(listaRefeicoes);
            }
            catch (Exception ex)
            {
                await ErroNegocio.EscreveErroBanco(ex);
                return RedirectToAction("ErroGenerico", "Erro");
            }

        }

        public async Task<IActionResult> InformacoesRefeicao(int refeicaoId)
        {
            var alimentoNegocio = new AlimentosNegocio(Contexto);
            var registroRefeicao = new RegistroRefeicoesViewModel();

            try
            {
                int idUsuarioRefeicao = await Contexto.RegistroRefeicoesViewModel.Where(r => r.Id == refeicaoId)
                                                                                 .Select(x => x.UsuarioId)
                                                                                 .FirstAsync();
                int idUsuarioLogado = BuscaIdUsuarioLogado();

                if(idUsuarioRefeicao != idUsuarioLogado)
                    return RedirectToAction("Index", "AcessoNegado");

                registroRefeicao = await alimentoNegocio.BuscaRegistroRefeicao(refeicaoId);
                return View("ResumoRefeicao", registroRefeicao);
            }
            catch (Exception ex)
            {               
                await ErroNegocio.EscreveErroBanco(ex);
                return RedirectToAction("ErroGenerico", "Erro");
            }
        }

        [HttpPost("/RegistrosRefeicoes/BuscaInformacoesAlimentos")]
        public async Task<IActionResult> BuscaInformacoesAlimentos(InformacoesAlimentosViewModel alimentoBuscar)
        {
            var alimentoNegocio = new AlimentosNegocio(Contexto);
            var resposta = new RespostaInformacoesAlimentos();

            try
            {
                var alimento = await alimentoNegocio.BuscaInformacaoAlimento(alimentoBuscar.Id, alimentoBuscar.Quantidade);

                resposta.Alimento = alimento;
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

        [HttpPost("/RegistrosRefeicoes/RegistraRefeicao")]
        public async Task<IActionResult> RegistraRefeicao(List<AlimentosViewModel> listaAlimentosAdicionados, string nomeRefeicao)
        {
            var alimentoNegocio = new AlimentosNegocio(Contexto);
            var resposta = new RespostaPadrao();

            try
            {
                if (ValidaRegistroRefeicao(listaAlimentosAdicionados, nomeRefeicao, ref resposta))
                {
                    await alimentoNegocio.CadastroRefeicao(listaAlimentosAdicionados, nomeRefeicao, BuscaIdUsuarioLogado());
                    resposta.Sucesso = true;
                }
            }
            catch (Exception ex)
            {
                resposta.Erro = true;
                resposta.Mensagem = ex.Message;
                await ErroNegocio.EscreveErroBanco(ex);
            }

            return Json(resposta);
        }

        private bool ValidaRegistroRefeicao(List<AlimentosViewModel> listaAlimentosAdicionados, string nomeRefeicao, ref RespostaPadrao resposta)
        {
            bool valida = true;

            if (string.IsNullOrEmpty(nomeRefeicao))
            {
                resposta.Dados.Add(new Erros { Id = "Nome", Erro = "Digite o nome da refeição" });
                valida = false;
            }
            else if(nomeRefeicao.Length < 5)
            {
                resposta.Dados.Add(new Erros { Id = "Nome", Erro = "Digite um nome com mais de 5 letras" });
                valida = false;
            }

            if(listaAlimentosAdicionados.Count == 0)
            {
                resposta.Dados.Add(new Erros { Id = "Refeicao", Erro = "Nenhum alimento cadastrado" });
                valida = false;
            }

            foreach(var alimento in listaAlimentosAdicionados)
            {
                if(alimento.Quantidade == 0)
                {
                    resposta.Dados.Add(new Erros { Id = "Refeicao", Erro = "Há um alimento com a quantidade incorreta" });
                    valida = false;
                    break;
                }

                if (alimento.InformacaoAlimentoId == 0)
                {
                    resposta.Dados.Add(new Erros { Id = "Refeicao", Erro = "Erro no cadastro de alimentos" });
                    valida = false;
                    break;
                }
            }
            return valida;
        }
    }
}
