using CleanArchitecture.Application.DTOs.Permission;

namespace CleanArchitecture.Application.Interfaces;

public interface IPermissionService
{
    Task<IEnumerable<UserPermissionsDto>> GetAllUsersWithPermissionsAsync();
    Task<UserPermissionsDto> GetUserPermissionsAsync(string userId);
    Task<UserPermissionsDto> UpdateUserPermissionsAsync(string userId, UpdateUserPermissionsDto permissionsDto);
    Task<IEnumerable<string>> GetAllPermissionsAsync();
}
