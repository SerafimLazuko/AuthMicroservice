using Auth.Domain.Infrastructure;

namespace Auth.Domain.Services;

/// <summary>
/// Обеспечивает функции аутентификации пользователей, такие как
/// проверка учетных данных, генерация токенов, и обработка внешней аутентификации.
/// </summary>
public interface IAuthenticationService
{
    Task<AuthenticationResult> AuthenticateAsync(string username, string password);
    Task<AuthenticationResult> AuthenticateWithExternalProviderAsync(string provider, ExternalLoginInfo loginInfo);
    Task LogoutAsync();
}