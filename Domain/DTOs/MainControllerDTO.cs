using Horta_Api.Application.Service.Validators;

namespace Horta_Api.Domain.DTOs
{
    public class MainControllerDTO
    {
        public string Ip {get; set;}

        public void Validate()
        {
            IpValidator.Validate(Ip);
        }
    }
}
