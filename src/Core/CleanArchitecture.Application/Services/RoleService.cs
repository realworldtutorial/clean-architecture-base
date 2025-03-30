using CleanArchitecture.Application.DTOs.Role;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Constants;
using CleanArchitecture.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RoleService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return roles.Select(r => new RoleDto
        {
            Id = r.Id,
            Name = r.Name!,
            Description = r.Description,
            Permissions = _roleManager.GetClaimsAsync(r).Result
                .Where(c => c.Type == "Permission")
                .Select(c => c.Value)
                .ToList()
        });
    }

    public async Task<RoleDto> GetRoleByIdAsync(string id)
    {
        var role = await _roleManager.FindByIdAsync(id) ??
            throw new KeyNotFoundException($"Role with ID {id} not found");

        var claims = await _roleManager.GetClaimsAsync(role);
        
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name!,
            Description = role.Description,
            Permissions = claims
                .Where(c => c.Type == "Permission")
                .Select(c => c.Value)
                .ToList()
        };
    }

    public async Task<RoleDto> CreateRoleAsync(CreateRoleDto roleDto)
    {
        var role = new ApplicationRole
        {
            Name = roleDto.Name,
            Description = roleDto.Description
        };

        var result = await _roleManager.CreateAsync(role);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Failed to create role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        // Add permissions as claims
        foreach (var permission in roleDto.Permissions)
        {
            await _roleManager.AddClaimAsync(role, new System.Security.Claims.Claim("Permission", permission));
        }

        return await GetRoleByIdAsync(role.Id);
    }

    public async Task<RoleDto> UpdateRoleAsync(string id, UpdateRoleDto roleDto)
    {
        var role = await _roleManager.FindByIdAsync(id) ??
            throw new KeyNotFoundException($"Role with ID {id} not found");

        role.Description = roleDto.Description;
        
        var result = await _roleManager.UpdateAsync(role);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Failed to update role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        // Remove existing permission claims
        var existingClaims = await _roleManager.GetClaimsAsync(role);
        foreach (var claim in existingClaims.Where(c => c.Type == "Permission"))
        {
            await _roleManager.RemoveClaimAsync(role, claim);
        }

        // Add new permission claims
        foreach (var permission in roleDto.Permissions)
        {
            await _roleManager.AddClaimAsync(role, new System.Security.Claims.Claim("Permission", permission));
        }

        return await GetRoleByIdAsync(role.Id);
    }

    public async Task DeleteRoleAsync(string id)
    {
        var role = await _roleManager.FindByIdAsync(id) ??
            throw new KeyNotFoundException($"Role with ID {id} not found");

        var result = await _roleManager.DeleteAsync(role);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Failed to delete role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
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

    public async Task AssignRoleToUserAsync(string userId, string roleId)
    {
        var user = await _userManager.FindByIdAsync(userId) ??
            throw new KeyNotFoundException($"User with ID {userId} not found");

        var role = await _roleManager.FindByIdAsync(roleId) ??
            throw new KeyNotFoundException($"Role with ID {roleId} not found");

        var result = await _userManager.AddToRoleAsync(user, role.Name!);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Failed to assign role to user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    public async Task RemoveRoleFromUserAsync(string userId, string roleId)
    {
        var user = await _userManager.FindByIdAsync(userId) ??
            throw new KeyNotFoundException($"User with ID {userId} not found");

        var role = await _roleManager.FindByIdAsync(roleId) ??
            throw new KeyNotFoundException($"Role with ID {roleId} not found");

        var result = await _userManager.RemoveFromRoleAsync(user, role.Name!);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Failed to remove role from user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}
