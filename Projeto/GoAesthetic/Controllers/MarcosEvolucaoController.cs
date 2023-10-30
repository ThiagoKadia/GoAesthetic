using GoAesthetic.Controllers.ControllersBase;
using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoAesthetic.Controllers
{
    public class MarcosEvolucaoController : BaseController
    {
        public MarcosEvolucaoController(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task<IActionResult> Index()
        {
            var marcoEvolucao = await Contexto.MarcosEvolucaoViewModel.FirstOrDefaultAsync();

            var storare = new StorageHelper();

            using (MemoryStream ms = await storare.DownloadImagem("PrimeiroArquivo"))
            {
                var fileBytes = ms.ToArray();
                marcoEvolucao.ArquivoBase64 = Convert.ToBase64String(fileBytes);
            }

            return View(marcoEvolucao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MarcosEvolucaoViewModel marcosEvolucao)
        {
            var storare = new StorageHelper();

            using (MemoryStream ms = new MemoryStream())
            {
                await marcosEvolucao.Arquivo.CopyToAsync(ms);
                ms.Position = 0;

                await storare.SalvarImagem(ms, "PrimeiroArquivo");
            }
            return View(marcosEvolucao);
        }
    }
}
