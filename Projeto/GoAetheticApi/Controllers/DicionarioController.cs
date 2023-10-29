using GoAestheticEntidades;
using GoAestheticNegocio.Constantes;
using GoAetheticApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoAetheticApi.Controllers
{
    [Route("v1/api/dictionary")]
    [ApiController]
    [Authorize(Roles = Roles.Sistema)]
    public class DicionarioController : ControllerBase
    {
        private GoAestheticDbContext _dbContext;
        public DicionarioController(GoAestheticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async ValueTask<ActionResult> GetPalavra(string chave)
        {
            try
            {
                var palavra = await _dbContext.DicionarioViewModel.FirstOrDefaultAsync(x => x.Chave.Equals(chave));

                if (string.IsNullOrEmpty(palavra.Valor))
                {
                    return NotFound(new BaseResponse()
                    {
                        Codigo = StatusCodes.Status404NotFound,
                        Mensagem = "Palavra não encontrada no Banco de Dados"
                    });
                }

                return Ok(new DicionarioResponse() 
                {
                    Codigo = StatusCodes.Status200OK,
                    Mensagem = "Sucesso",
                    Palavra = palavra.Valor
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse()
                {
                    Codigo = StatusCodes.Status400BadRequest,
                    Mensagem = ex.Message
                });
            }
        }
    }
}
