// Application/Services/UserService.cs

using Horta.Domain.Model;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<bool> ExistsByEmailAsync(string email);
    Task<User> GetEmailAsync(string email);
}