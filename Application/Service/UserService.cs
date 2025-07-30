// Horta_Api.Application.Service.UserService.cs
using Horta.Domain.Model;
using Horta_Api.Application.Service;
using Horta_Api.Domain.DTOs;
using Horta_Api.Infrastructure.Security;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    // Construtor tradicional (a sintaxe que você usou com * não é válida)
    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<User> CreateUserAsync(CreateUserDto createUserDto)
    {
        
        createUserDto.Validate();

        
        if (await _userRepository.ExistsByEmailAsync(createUserDto.Email))
            throw new InvalidOperationException("Email já está em uso");

        
        var user = new User()
        {
            Username = createUserDto.Username,
            Email = createUserDto.Email,
            IpAddress = createUserDto.IpAddress,
            UserAgent = createUserDto.UserAgent,
            Password = _passwordHasher.HashPassword(createUserDto.Password),
            CreatedAt = DateTime.UtcNow
        };

        
        var createdUser = await _userRepository.CreateAsync(user);

        
        return createdUser;


    }

    public async Task<UserLoginResponseDto> LoginAsync(UserLoginDto loginDto)
    {
        var user = await _userRepository.GetEmailAsync(loginDto.Email);
        
        if (user == null)
            throw new InvalidOperationException("Usuário não encontrado");


        if (!_passwordHasher.VerifyPassword(loginDto.Password, user.Password))
            throw new UnauthorizedAccessException("Credenciais inválidas");

        var token = TokenService.GenerateToken(user);

        return new UserLoginResponseDto
        {
            UserId = user.UserId,
            Username = user.Username
        };
    }


}
