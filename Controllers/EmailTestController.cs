using Horta.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Horta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailTestController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailTestController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-test-email")]
        public async Task<IActionResult> SendTestEmail([FromQuery] string toEmail, [FromQuery] string subject, [FromBody] string body)
        {
            if (string.IsNullOrEmpty(toEmail) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                return BadRequest("Por favor, forneça o e-mail do destinatário, o assunto e o corpo do e-mail.");
            }

            try
            {
                await _emailService.SendEmailAsync(toEmail, subject, body);
                return Ok($"E-mail de teste enviado com sucesso para {toEmail}.");
            }
            catch (Exception ex)
            {
                // Log the exception (use a proper logging framework in a real application)
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                return StatusCode(500, $"Erro ao enviar e-mail: {ex.Message}");
            }
        }
    }
}


