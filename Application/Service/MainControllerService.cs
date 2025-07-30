using Horta_Api.Infrastructure.Repositories;
using Horta.Domain.Model;
using Horta_Api.Application.Service;
using Horta_Api.Domain.DTOs;

namespace Horta_Api.Application.Service
{
    public class MainControllerService
    {
        private readonly IMainControllerService _mainControllerService;
        private readonly IMainControllerSetupHandler _mainControllerSetupHandler;

        public MainControllerService(IMainControllerSetupHandler mainControllerSetupHandler, IMainControllerService mainControllerService)
        {
            _mainControllerSetupHandler = mainControllerSetupHandler;
            _mainControllerService = _mainControllerService;

        }

        public async Task<MainController> CreateAsync(MainControllerDTO controller, int userId)

        {
            controller.Validate();


            var mainController = new MainController
            {
                IpAddress = controller.Ip,
                UserId = userId

            };




            var createdController = await _mainControllerSetupHandler.CreateAsync(mainController);
            return createdController;
        }



    }
}
