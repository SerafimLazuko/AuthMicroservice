using System.Security.Claims;

namespace Auth.Domain.Models;

public class Role
{
    public Guid Id { get; private set; }
    /// <summary>
    /// имя роли
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// коллекция утверждений, связанных с ролью
    /// </summary>
    public ICollection<Claim> Claims { get; private set; }

    public Role(string name)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Claims = new List<Claim>();
    }

    public void AddClaim(Claim claim)
    {
        Claims.Add(claim);
    }
}