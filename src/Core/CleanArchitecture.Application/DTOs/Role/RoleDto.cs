namespace CleanArchitecture.Application.DTOs.Role;

public class RoleDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public List<string> Permissions { get; set; } = new();
}
