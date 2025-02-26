using Auth.Domain.Infrastructure;
using Auth.Domain.Models;

namespace Auth.Domain.Services;

/// <summary>
/// Обеспечивает интерфейс для интеграции с внешними провайдерами аутентификации (Google, Facebook и т.д.).
/// </summary>
public interface IExternalAuthenticationService
{
    Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string provider);
    Task<bool> LinkExternalAccountAsync(User user, ExternalLoginInfo loginInfo);
}