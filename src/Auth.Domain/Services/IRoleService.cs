using Auth.Domain.Models;

namespace Auth.Domain.Services;

public interface IRoleService
{
    Task<Role> CreateRoleAsync(string roleName);
    Task AssignRoleToUserAsync(Guid userId, string roleName);
}