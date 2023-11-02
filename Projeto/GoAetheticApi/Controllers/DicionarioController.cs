using GoAestheticApi.Repositories;
using GoAestheticComuns.Constantes;
using GoAestheticEntidades.Entities;
using GoAetheticApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoAetheticApi.Controllers
{
    [Route("v1/api/dicionario")]
    [ApiController]
    [Authorize(Roles = Roles.Sistema)]
    public class DicionarioController : ControllerBase
    {
        private readonly LogRepository _logRepository;
        private DicionarioRepository _dicionarioRepository;

        public DicionarioController(DicionarioRepository dicionarioRepository, LogRepository logRepository)
        {
            _dicionarioRepository = dicionarioRepository;
            _logRepository = logRepository;
        }

        [HttpGet]
        public async ValueTask<ActionResult> GetPalavra(string chave)
        {
            try
            {
                var palavra = await _dicionarioRepository.GetSignificado(chave);

                if (string.IsNullOrEmpty(palavra))
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
                    Palavra = palavra
                });
            }
            catch (Exception ex)
            {
                await _logRepository.InsereLog(new LogViewModel()
                {
                    Data = DateTime.Now,
                    Erro = ex.Message,
                    StackTrace = ex.StackTrace
                });

                return BadRequest(new BaseResponse()
                {
                    Codigo = StatusCodes.Status400BadRequest,
                    Mensagem = ex.Message
                });
            }
        }
    }
}