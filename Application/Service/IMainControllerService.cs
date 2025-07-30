using Horta.Domain.Model;
using Horta_Api.Domain.DTOs;

namespace Horta_Api.Application.Service
{
    public interface IMainControllerService
    {
       public Task<MainController> CreateAsync(MainControllerDTO controller);
    }
}
