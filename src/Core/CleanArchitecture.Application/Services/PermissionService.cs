using CleanArchitecture.Application.DTOs.Permission;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Constants;
using CleanArchitecture.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CleanArchitecture.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public PermissionService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<UserPermissionsDto>> GetAllUsersWithPermissionsAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var userPermissions = new List<UserPermissionsDto>();

        foreach (var user in users)
        {
            var permissions = await _userManager.GetClaimsAsync(user);
            userPermissions.Add(new UserPermissionsDto
            {
                UserId = user.Id,
                Email = user.Email!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Permissions = permissions
                    .Where(c => c.Type == "Permission")
                    .Select(c => c.Value)
                    .ToList()
            });
        }

        return userPermissions;
    }

    public async Task<UserPermissionsDto> GetUserPermissionsAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId) ??
            throw new KeyNotFoundException($"User with ID {userId} not found");

        var permissions = await _userManager.GetClaimsAsync(user);

        return new UserPermissionsDto
        {
            UserId = user.Id,
            Email = user.Email!,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Permissions = permissions
                .Where(c => c.Type == "Permission")
                .Select(c => c.Value)
                .ToList()
        };
    }

    public async Task<UserPermissionsDto> UpdateUserPermissionsAsync(string userId, UpdateUserPermissionsDto permissionsDto)
    {
        var user = await _userManager.FindByIdAsync(userId) ??
            throw new KeyNotFoundException($"User with ID {userId} not found");

        // Remove existing permission claims
        var existingClaims = await _userManager.GetClaimsAsync(user);
        foreach (var claim in existingClaims.Where(c => c.Type == "Permission"))
        {
            await _userManager.RemoveClaimAsync(user, claim);
        }

        // Add new permission claims
        foreach (var permission in permissionsDto.Permissions)
        {
            await _userManager.AddClaimAsync(user, new Claim("Permission", permission));
        }

        return await GetUserPermissionsAsync(userId);
    }

    public Task<IEnumerable<string>> GetAllPermissionsAsync()
    {
        var permissions = new List<string>
        {
            Permissions.TodoView,
            Permissions.TodoCreate,
            Permissions.TodoEdit,
            Permissions.TodoDelete
        };

        return Task.FromResult<IEnumerable<string>>(permissions);
    }
}
