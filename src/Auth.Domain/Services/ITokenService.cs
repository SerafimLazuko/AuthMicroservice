using System.Security.Claims;
using Auth.Domain.Models;

namespace Auth.Domain.Services;

/// <summary>
/// Отвечает за создание, валидацию и обновление токенов доступа и обновления (access tokens и refresh tokens).
/// </summary>
public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal ValidateAccessToken(string token);
    bool ValidateRefreshToken(User user, string refreshToken);
}