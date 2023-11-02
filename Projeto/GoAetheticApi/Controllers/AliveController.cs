using GoAestheticEntidades;
using GoAetheticApi.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GoAestheticApi.Controllers
{
    [Route("v1/api/is-alive")]
    [ApiController]
    public class AliveController : ControllerBase
    {
        GoAestheticDbContext Contexto;

        public AliveController(GoAestheticDbContext dbContext)
        {
            Contexto = dbContext;
        }


        [HttpGet]
        public ActionResult EstouVivo()
        {
            var conexao = Contexto.Database.CanConnect();

            if(conexao)
            {
                return Ok(new BaseResponse()
                {
                    Codigo = StatusCodes.Status200OK,
                    Mensagem = "Estou Vivo"
                });
            }
            else
            {
                return StatusCode(500, new BaseResponse()
                {
                    Codigo = StatusCodes.Status500InternalServerError,
                    Mensagem = "Falha ao conectar ao banco"
                });
            }

        }
    }
}
