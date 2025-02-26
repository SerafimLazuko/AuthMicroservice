namespace Auth.Domain.Models;

public class Client
{
    /// <summary>
    /// уникальный идентификатор клиента
    /// </summary>
    public string ClientId { get; private set; }
    /// <summary>
    /// название клиента
    /// </summary>
    public string ClientName { get; private set; }
    /// <summary>
    /// список разрешенных GrantType
    /// </summary>
    public ICollection<string> AllowedGrantTypes { get; private set; }
    /// <summary>
    /// URL-адреса для перенаправления после аутентификации
    /// </summary>
    public ICollection<string> RedirectUris { get; private set; }
    /// <summary>
    /// URL-адреса для перенаправления после выхода
    /// </summary>
    public ICollection<string> PostLogoutRedirectUris { get; private set; }
    /// <summary>
    /// список разрешенных скоупов
    /// </summary>
    public ICollection<string> AllowedScopes { get; private set; }
    /// <summary>
    /// секреты клиента для аутентификации
    /// </summary>
    public ICollection<ClientSecret> ClientSecrets { get; private set; }

    public Client(string clientId, string clientName)
    {
        ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
        ClientName = clientName;
        AllowedGrantTypes = new List<string>();
        RedirectUris = new List<string>();
        PostLogoutRedirectUris = new List<string>();
        AllowedScopes = new List<string>();
        ClientSecrets = new List<ClientSecret>();
    }

    public void AddRedirectUri(string uri)
    {
        RedirectUris.Add(uri);
    }

    public void AddScope(string scope)
    {
        AllowedScopes.Add(scope);
    }
}