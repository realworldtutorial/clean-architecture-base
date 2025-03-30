using CleanArchitecture.Application.DTOs.Permission;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "ManagePermissions")] // Only users with ManagePermissions permission can access this controller
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<UserPermissionsDto>>> GetAllUsersWithPermissions()
    {
        var usersWithPermissions = await _permissionService.GetAllUsersWithPermissionsAsync();
        return Ok(usersWithPermissions);
    }

    [HttpGet("users/{userId}")]
    public async Task<ActionResult<UserPermissionsDto>> GetUserPermissions(string userId)
    {
        try
        {
            var userPermissions = await _permissionService.GetUserPermissionsAsync(userId);
            return Ok(userPermissions);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("users/{userId}")]
    public async Task<ActionResult<UserPermissionsDto>> UpdateUserPermissions(string userId, UpdateUserPermissionsDto permissionsDto)
    {
        try
        {
            var updatedPermissions = await _permissionService.UpdateUserPermissionsAsync(userId, permissionsDto);
            return Ok(updatedPermissions);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("available")]
    public async Task<ActionResult<IEnumerable<string>>> GetAllPermissions()
    {
        var permissions = await _permissionService.GetAllPermissionsAsync();
        return Ok(permissions);
    }
}
