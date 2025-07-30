using Horta.Domain.Model;
using Horta_Api.Domain.DTOs;

namespace Horta_Api.Application.Service
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserLoginResponseDto> LoginAsync(UserLoginDto loginDto);


    }
}