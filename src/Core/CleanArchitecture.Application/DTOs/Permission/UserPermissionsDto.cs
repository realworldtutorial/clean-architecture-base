namespace CleanArchitecture.Application.DTOs.Permission;

public class UserPermissionsDto
{
    public required string UserId { get; set; }
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public List<string> Permissions { get; set; } = new();
}
