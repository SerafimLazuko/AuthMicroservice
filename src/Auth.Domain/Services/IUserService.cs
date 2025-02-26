using Auth.Domain.Models;

namespace Auth.Domain.Services;

public interface IUserService
{
    Task<User> RegisterUserAsync(string username, string email, string password);
    Task<bool> ValidateUserCredentialsAsync(string username, string password);
    Task<User> FindByUsernameAsync(string username);
    Task<User> FindByIdAsync(Guid userId);
}