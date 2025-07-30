using Microsoft.AspNetCore.Mvc; // Usado para construir APIs
using Horta_Api.Application.Service; // Onde está sua UserService
using Horta_Api.Domain.DTOs; // Onde está o DTO CreateUserDto
using Horta.Domain.Model;
using System.CodeDom.Compiler; // Onde está a entidade User

namespace Horta_Api.Controllers
{
    [ApiController] // Diz que é um controller de API
    [Route("api/[controller]")] // Define a rota: api/users
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        // Construtor que recebe sua service
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto dto)
        {
            try
            {
                var user = await _userService.CreateUserAsync(dto); // chama seu service
                var token = TokenService.GenerateToken(user); // gera o token JWT
                return Ok(token); // retorna o usuário criado
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message }); // se der erro, retorna 400
            }
        }
    }
}
