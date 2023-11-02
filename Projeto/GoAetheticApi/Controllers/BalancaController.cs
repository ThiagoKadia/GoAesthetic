using GoAestheticApi.Repositories;
using GoAestheticEntidades.Entities;
using GoAestheticComuns.Constantes;
using GoAetheticApi.Models.Request;
using GoAetheticApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoAetheticApi.Controllers
{
    [Route("v1/api/balanca")]
    [ApiController]
    [Authorize(Roles = Roles.Balanca)]
    public class BalancaController : ControllerBase
    {
        private readonly BalancaRepository _balancaRepository;
        private readonly MarcoEvolucaoRepository _marcoEvolucaoRepository;
        public BalancaController(BalancaRepository balancaRepository, MarcoEvolucaoRepository marcoEvolucaoRepository)
        {
            _balancaRepository = balancaRepository;
            _marcoEvolucaoRepository = marcoEvolucaoRepository;
        }

        [HttpPost("envia-peso")]
        public async ValueTask<ActionResult> EnviaPeso([FromBody] BalancaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!ValidateParameters(request, out var errorResponse))
            {
                return BadRequest(errorResponse);
            }

            var marcoAtualizado = await AtualizaMarco(request);

            await _balancaRepository.SalvaPeso(marcoAtualizado);

            var balanceResponse = new BaseResponse()
            {
                Codigo = StatusCodes.Status200OK,
                Mensagem = "Successo"
            };

            return Ok(balanceResponse);
        }

        private async ValueTask<MarcosEvolucaoViewModel> AtualizaMarco(BalancaRequest request) 
        {
            var ultimoMarco = await _marcoEvolucaoRepository.SelectUltimoMarco(request.Usuario);
            ultimoMarco.Peso = request.Peso;
            ultimoMarco.DataInclusao = request.Data;

            return ultimoMarco;
        }

        private bool ValidateParameters(BalancaRequest request, out BaseResponse errorResponse)
        {
            errorResponse = null;

            try
            {
                if (string.IsNullOrEmpty(request.CodBalanca))
                {
                    errorResponse = new BaseResponse
                    {
                        Codigo = StatusCodes.Status400BadRequest,
                        Mensagem = "BalanceCode parameter must be valid"
                    };

                    return false;
                }

                if (string.IsNullOrEmpty(request.Usuario))
                {
                    errorResponse = new BaseResponse
                    {
                        Codigo = StatusCodes.Status400BadRequest,
                        Mensagem = "Username parameter must be valid"
                    };

                    return false;
                }

                if (request.Peso <= 0)
                {
                    errorResponse = new BaseResponse
                    {
                        Codigo = StatusCodes.Status400BadRequest,
                        Mensagem = "Weight parameter must be valid"
                    };

                    return false;
                }
            }
            catch (Exception ex)
            {
                errorResponse = new BaseResponse
                {
                    Codigo = StatusCodes.Status400BadRequest,
                    Mensagem = ex.Message
                };
            }

            return true;
        }
    }
}