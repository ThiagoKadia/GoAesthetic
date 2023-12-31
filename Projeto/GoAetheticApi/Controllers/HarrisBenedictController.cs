﻿using GoAestheticComuns.Constantes;
using GoAetheticApi.Models.Request;
using GoAetheticApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoAetheticApi.Controllers
{
    [Route("v1/api/harris-benedict")]
    [ApiController]
    [Authorize(Roles = Roles.Sistema)]
    public class HarrisBenedictController : ControllerBase
    {
        [HttpPost("mulher")]
        public ActionResult HarrisBenedicWomen([FromBody] HarrisBenedictRequest request)
        {
            if (!ModelState.IsValid)
            {
                var baseResponse = new BaseResponse()
                {
                    Codigo = StatusCodes.Status400BadRequest,
                    Mensagem = "Invalid Model"
                };

                return BadRequest(baseResponse);
            }

            if (!ValidateParameters(request, out var errorResponse))
            {
                return BadRequest(errorResponse);
            }

            var tmb = Math.Floor(655.0955 + (1.8496 * request.Altura) + (9.5634 * request.Peso) - (4.6756 * request.Idade));

            return ValidateTmb(tmb);
        }

        [HttpPost("homem")]
        public ActionResult HarrisBenedicMen([FromBody] HarrisBenedictRequest request)
        {
            if (!ModelState.IsValid)
            {
                var baseResponse = new BaseResponse()
                {
                    Codigo = StatusCodes.Status400BadRequest,
                    Mensagem = "Invalid Model"
                };

                return BadRequest(baseResponse);
            }

            if (!ValidateParameters(request, out var errorResponse))
            {
                return BadRequest(errorResponse);
            }

            var tmb = Math.Floor(66.4730 + (5.0033 * request.Altura + 13.7516 * request.Peso - 6.7550 * request.Idade));

            return ValidateTmb(tmb);
        }

        private ActionResult ValidateTmb(double tmb)
        {
            if (tmb < 0)
            {
                var errorResponse = new BaseResponse()
                {
                    Codigo = StatusCodes.Status400BadRequest,
                    Mensagem = "Check informed parameters, TMB cannot be negative"
                };

                return BadRequest(errorResponse);
            }

            var harrisBenedictResponse = new HarrisBenedictResponse()
            {
                Codigo = StatusCodes.Status200OK,
                Mensagem = "Success",
                TaxaMetabolica = tmb
            };

            return Ok(harrisBenedictResponse);
        }

        private bool ValidateParameters(HarrisBenedictRequest request, out BaseResponse errorResponse)
        {
            errorResponse = null;
            try
            {
                if (request.Idade <= 0)
                {
                    errorResponse = new BaseResponse
                    {
                        Codigo = StatusCodes.Status400BadRequest,
                        Mensagem = "Age parameter must be valid"
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

                if (request.Altura <= 0)
                {
                    errorResponse = new BaseResponse
                    {
                        Codigo = StatusCodes.Status400BadRequest,
                        Mensagem = "Height parameter must be valid"
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

                return false;
            }

            return true;
        }
    }
}