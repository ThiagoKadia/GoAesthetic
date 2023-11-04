using GoAesthetic.Controllers.ControllersBase;
using GoAesthetic.Models;
using GoAestheticEntidades;
using GoAestheticNegocio.Implementacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GoAesthetic.Controllers
{
    public class HistoricoRefeicaoController : BaseController
    {
        public HistoricoRefeicaoController(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task<IActionResult> Index()
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
                return RedirectToAction("Index", "Erro");
            }

        }
    }
}