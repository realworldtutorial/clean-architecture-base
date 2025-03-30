namespace CleanArchitecture.Application.DTOs.Permission;

public class UpdateUserPermissionsDto
{
    public List<string> Permissions { get; set; } = new();
}
