
using Horta_Api.Application.Interfaces;
using Horta_Api.Application.Service;
using Horta_Api.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Horta_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailVerificationController : ControllerBase
    {
        private readonly IEmailVerificationService _emailVerificationService;
        private readonly IUserService _userService;

        public EmailVerificationController(IEmailVerificationService emailVerificationService, IUserService userService)
        {
            _emailVerificationService = emailVerificationService;
            _userService = userService;
        }

        [HttpPost("send-verification-code")]
        public async Task<IActionResult> SendVerificationCode([FromQuery] string toEmail)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
                return BadRequest("Por favor, forneça o e-mail do destinatário.");

            try
            {
                await _emailVerificationService.SendVerificationCodeAsync(toEmail);
                return Ok($"Código de verificação enviado com sucesso para {toEmail}.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("validate-code")]
        public async Task<IActionResult> ValidateCode([FromBody] CreateUserDto dto, [FromQuery] string email, [FromQuery] int code)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("Por favor, forneça o e-mail.");

            try
            {
                var isValid = await _emailVerificationService.ValidateCodeAsync(email, code);
                if (!isValid)
                    return BadRequest("Código inválido, expirado ou já utilizado.");

                // Cria o usuário após validação bem-sucedida
                var user = await _userService.CreateUserAsync(dto);
                var token = TokenService.GenerateToken(user);
                return Ok(new { token = token, user = user });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}