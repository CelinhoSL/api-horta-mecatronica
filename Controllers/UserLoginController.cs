using Microsoft.AspNetCore.Mvc;
using Horta_Api.Application.Service;
using Horta_Api.Domain.DTOs;

namespace Horta_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserLoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            try
            {
                // Captura IP e agente de usuário
                loginDto.IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                loginDto.UserAgent = Request.Headers["User-Agent"].ToString();

                // Chama o serviço de login
                var result = await _userService.LoginAsync(loginDto);

                // Retorna 200 OK com os dados do login
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Tratar erros inesperados
                return StatusCode(500, new { message = "Erro interno no servidor.", detail = ex.Message });
            }
        }
    }
}
