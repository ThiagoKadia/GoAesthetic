using GoAesthetic.Controllers.ControllersBase;
using GoAesthetic.Models;
using GoAestheticEntidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GoAesthetic.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var alimentos = await contexto.AlimentosViewModel.ToListAsync();
            var grupoAlimentos = await contexto.GrupoAlimentoViewModel.ToListAsync();
            var informacoesAlimentos = await contexto.InformacoesAlimentosViewModel.ToListAsync();
            var marcosEvolucao = await contexto.MarcosEvolucaoViewModel.ToListAsync();
            var registroRefeicoes = await contexto.RegistroRefeicoesViewModel.ToListAsync();
            var usuarios = await contexto.UsuariosViewModel.ToListAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}