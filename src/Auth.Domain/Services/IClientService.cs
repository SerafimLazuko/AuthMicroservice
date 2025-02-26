using Auth.Domain.Models;

namespace Auth.Domain.Services;

public interface IClientService
{
    Task<Client> GetClientByIdAsync(string clientId);
    Task<bool> ValidateClientCredentialsAsync(string clientId, string clientSecret);
}