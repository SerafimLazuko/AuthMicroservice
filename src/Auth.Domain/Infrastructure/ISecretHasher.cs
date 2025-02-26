namespace Auth.Domain.Infrastructure;

public interface ISecretHasher
{
    public string Hash(string secret);
}