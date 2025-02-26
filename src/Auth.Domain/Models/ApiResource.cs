namespace Auth.Domain.Models;

public class ApiResource
{
    /// <summary>
    /// уникальное имя API ресурса
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// отображаемое имя
    /// </summary>
    public string DisplayName { get; private set; }
    /// <summary>
    /// список скоупов, связанных с ресурсом
    /// </summary>
    public ICollection<string> Scopes { get; private set; }
    /// <summary>
    /// секреты для доступа к ресурсу, если необходимо
    /// </summary>
    public ICollection<ClientSecret> Secrets { get; private set; }

    public ApiResource(string name, string displayName)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        DisplayName = displayName;
        Scopes = new List<string>();
        Secrets = new List<ClientSecret>();
    }

    public void AddScope(string scope)
    {
        Scopes.Add(scope);
    }

    // Другие методы...
}