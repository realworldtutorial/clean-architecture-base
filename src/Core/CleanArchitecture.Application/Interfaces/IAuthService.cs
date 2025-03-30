using CleanArchitecture.Application.DTOs.Auth;

namespace CleanArchitecture.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
    Task<List<string>> GetUserPermissionsAsync(string userId);
}
