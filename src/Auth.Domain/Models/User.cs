using System.Security.Claims;
using Auth.Domain.Infrastructure;

namespace Auth.Domain.Models;

public class User
{
    public Guid Id { get; private set; }
    /// <summary>
    /// имя пользователя
    /// </summary>
    public string Username { get; private set; }
    /// <summary>
    /// адрес электронной почты
    /// </summary>
    public string Email { get; private set; }
    /// <summary>
    /// хеш пароля пользователя
    /// </summary>
    public string PasswordHash { get; private set; }
    /// <summary>
    /// используется для безопасности (например, при сбросе пароля)
    /// </summary>
    public string SecurityStamp { get; private set; }
    /// <summary>
    /// коллекция ролей пользователя
    /// </summary>
    public ICollection<Role> Roles { get; private set; }
    /// <summary>
    /// коллекция утверждений (Claim), связанных с пользователем
    /// </summary>
    public ICollection<Claim> Claims { get; private set; }

    public User(string username, string email)
    {
        Id = Guid.NewGuid();
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Roles = new List<Role>();
        Claims = new List<Claim>();
        SecurityStamp = Guid.NewGuid().ToString();
    }

    public void SetPassword(string password, IPasswordHasher passwordHasher)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Пароль не может быть пустым", nameof(password));

        PasswordHash = passwordHasher.HashPassword(password);
    }

    public bool CheckPassword(string password, IPasswordHasher passwordHasher)
    {
        return passwordHasher.VerifyHashedPassword(PasswordHash, password);
    }

    public void AddRole(Role role)
    {
        Roles.Add(role);
    }

    public void AddClaim(Claim claim)
    {
        Claims.Add(claim);
    }
}