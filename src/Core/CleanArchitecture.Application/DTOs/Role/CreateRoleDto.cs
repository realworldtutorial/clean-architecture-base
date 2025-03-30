namespace CleanArchitecture.Application.DTOs.Role;

public class CreateRoleDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public List<string> Permissions { get; set; } = new();
}
