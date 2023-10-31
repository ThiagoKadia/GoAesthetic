using GoAetheticApi.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GoAestheticApi.Controllers
{
    [Route("v1/api/is-alive")]
    [ApiController]
    public class AliveController : ControllerBase
    {

        [HttpGet]
        public ActionResult EstouVivo()
        {
            return Ok(new BaseResponse()
            {
                Codigo = StatusCodes.Status200OK,
                Mensagem = "Estou Vivo"
            });
        }
    }
}
