using Horta_Api.Application.Service;
using Horta.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace Horta_Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ConnectionContext _context = new ConnectionContext();

        private readonly List<User> _users = [];

        public async Task<User> CreateAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<bool> ExistsByEmailAsync(string email)
        {
            return Task.FromResult(_users.Any(u => u.Email == email));
        }

        public async Task<User> GetEmailAsync(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email);

        }
    }
}
