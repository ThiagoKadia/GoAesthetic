using GoAestheticApi.Repositories;
using GoAetheticApi.Models.Request;
using GoAetheticApi.Models.Response;
using GoAetheticApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoAetheticApi.Controllers
{
    [Route("v1/api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthRepository _authRepository;
        private TokenService _tokenService;

        public AuthController(AuthRepository authRepository, TokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async ValueTask<ActionResult> GetToken([FromBody] AuthRequest user)
        {
            try
            {
                var usuarioAutenticado = await _authRepository.SelectUser(user);

                if (usuarioAutenticado == null)
                {
                    return NotFound(new BaseResponse()
                    {
                        Codigo = StatusCodes.Status404NotFound,
                        Mensagem = "Usuario ou Senha Inválidos",
                    });
                }

                var token = _tokenService.GerarToken(usuarioAutenticado);

                return Ok(new AuthResponse
                {
                    Codigo = StatusCodes.Status200OK,
                    Mensagem = "Sucesso",
                    Token = token,
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse()
                {
                    Codigo = StatusCodes.Status400BadRequest,
                    Mensagem = ex.Message
                });
            };
        }
    }
}
