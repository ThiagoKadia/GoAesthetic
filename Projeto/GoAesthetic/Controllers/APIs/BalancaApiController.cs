using GoAesthetic.Models.API;
using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers.APIs
{
    [Route("v1/api/balanca")]
    [ApiController]
    public class BalancaApiController : ControllerBase
    {
        [HttpPost("EnvioPeso")]
        public async Task<ActionResult> EnvioPeso([FromBody] DadosBalancaModel Peso)
        {
            return Ok(Peso);
        }
    }
}
