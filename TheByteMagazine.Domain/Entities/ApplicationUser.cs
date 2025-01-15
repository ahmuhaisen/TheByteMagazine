using Microsoft.AspNetCore.Identity;

namespace TheByteMagazine.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public string? UniversityId { get; set; }
}
