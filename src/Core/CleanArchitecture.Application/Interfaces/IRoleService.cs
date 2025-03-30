using CleanArchitecture.Application.DTOs.Role;

namespace CleanArchitecture.Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    Task<RoleDto> GetRoleByIdAsync(string id);
    Task<RoleDto> CreateRoleAsync(CreateRoleDto roleDto);
    Task<RoleDto> UpdateRoleAsync(string id, UpdateRoleDto roleDto);
    Task DeleteRoleAsync(string id);
    Task<IEnumerable<string>> GetAllPermissionsAsync();
    Task AssignRoleToUserAsync(string userId, string roleId);
    Task RemoveRoleFromUserAsync(string userId, string roleId);
}
