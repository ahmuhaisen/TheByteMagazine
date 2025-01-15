using System.ComponentModel.DataAnnotations;

namespace TheByteMagazine.Application.DTOs.Authentication;

public class RegisterRequest
{
    [EmailAddress]
    public required string Email { get; set; }

    [MaxLength(50)]
    public required string Password { get; set; }

    [MinLength(10)]
    public required string FullName { get; set; }

    [Length(7, 8)]
    public required string UniversityId { get; set; }

    [Phone]
    public required string PhoneNumber { get; set; }
}