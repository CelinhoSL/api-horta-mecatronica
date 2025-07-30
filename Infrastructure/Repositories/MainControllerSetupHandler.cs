using Horta.Domain.Model;

namespace Horta_Api.Infrastructure.Repositories
{
    public class MainControllerSetupHandler : IMainControllerSetupHandler
    {

        private readonly ConnectionContext _context = new ConnectionContext();


        public async Task<MainController> CreateAsync(MainController controller)
        {
            _context.MainController.Add(controller);
            await _context.SaveChangesAsync();
            return controller;
        }


    }
}
