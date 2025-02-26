namespace Auth.Domain.Models;

public class ApiScope
{
    /// <summary>
    /// уникальное имя скоупа
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// отображаемое имя
    /// </summary>
    public string DisplayName { get; private set; }
    /// <summary>
    /// список утверждений, предоставляемых при запросе данного скоупа
    /// </summary>
    public ICollection<string> UserClaims { get; private set; }

    public ApiScope(string name, string displayName)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        DisplayName = displayName;
        UserClaims = new List<string>();
    }

    public void AddUserClaim(string claim)
    {
        UserClaims.Add(claim);
    }
}