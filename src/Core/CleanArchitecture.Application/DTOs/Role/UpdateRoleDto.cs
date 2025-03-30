namespace CleanArchitecture.Application.DTOs.Role;

public class UpdateRoleDto
{
    public required string Description { get; set; }
    public List<string> Permissions { get; set; } = new();
}
