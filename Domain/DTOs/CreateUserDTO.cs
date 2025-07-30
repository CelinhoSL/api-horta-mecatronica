using Horta_Api.Aplication.Service.Validators;
using Horta_Api.Application.Service.Validators;

namespace Horta_Api.Domain.DTOs
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } 
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public void Validate()
        {
            UsernameValidator.Validate(Username);
            PasswordValidator.Validate(Password);
            EmailValidator.Validate(Email);
            IpValidator.Validate(IpAddress);

        }
    }

}
