using Auth.Domain.Infrastructure;

namespace Auth.Domain.Models;

public class ClientSecret
{
    public string Value { get; private set; }
    public string Type { get; private set; }
    public DateTime? Expiration { get; private set; }
    public string Description { get; private set; }

    public ClientSecret(string value, string type = "SharedSecret", DateTime? expiration = null, string description = null)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
        Type = type;
        Expiration = expiration;
        Description = description;
    }

    public void HashSecret(ISecretHasher hasher)
    {
        Value = hasher.Hash(Value);
    }
}