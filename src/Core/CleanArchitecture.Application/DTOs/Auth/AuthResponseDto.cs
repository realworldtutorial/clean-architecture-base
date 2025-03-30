namespace CleanArchitecture.Application.DTOs.Auth;

public class AuthResponseDto
{
    public required string Token { get; set; }
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required List<string> Roles { get; set; }
    public required List<string> Permissions { get; set; }
}
