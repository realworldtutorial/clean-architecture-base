using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Models;

public class ApplicationRole : IdentityRole
{
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
