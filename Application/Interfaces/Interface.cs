namespace Horta_Api.Application.Interfaces
{
    public interface IEmailVerificationService
    {
        Task<bool> SendVerificationCodeAsync(string email);
        Task<bool> ValidateCodeAsync(string email, int code);
    }
}