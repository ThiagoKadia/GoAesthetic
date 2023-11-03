using GoAesthetic.Controllers.ControllersBase;
using GoAestheticEntidades;
using GoAestheticNegocio.Implementacao;
using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class GaleriaController : BaseController 
    {
        public GaleriaController(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task <IActionResult> Index()
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
                return RedirectToAction("Index", "Erro");
            }
            
        }
            
        
    }
}
