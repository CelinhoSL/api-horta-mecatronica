using Horta.Domain.Model;
using Horta_Api.Domain.DTOs;

namespace Horta_Api.Infrastructure.Repositories
{
    public interface IMainControllerSetupHandler
    {

        Task<MainController> CreateAsync(MainController controller);
        
    }
}
