using CleanArchitecture.Application.DTOs.Role;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")] // Only admin can manage roles
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDto>> GetById(string id)
    {
        try
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            return Ok(role);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<RoleDto>> Create(CreateRoleDto roleDto)
    {
        try
        {
            var role = await _roleService.CreateRoleAsync(roleDto);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RoleDto>> Update(string id, UpdateRoleDto roleDto)
    {
        try
        {
            var role = await _roleService.UpdateRoleAsync(id, roleDto);
            return Ok(role);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("permissions")]
    public async Task<ActionResult<IEnumerable<string>>> GetAllPermissions()
    {
        var permissions = await _roleService.GetAllPermissionsAsync();
        return Ok(permissions);
    }

    [HttpPost("users/{userId}/roles/{roleId}")]
    public async Task<IActionResult> AssignRoleToUser(string userId, string roleId)
    {
        try
        {
            await _roleService.AssignRoleToUserAsync(userId, roleId);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("users/{userId}/roles/{roleId}")]
    public async Task<IActionResult> RemoveRoleFromUser(string userId, string roleId)
    {
        try
        {
            await _roleService.RemoveRoleFromUserAsync(userId, roleId);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
