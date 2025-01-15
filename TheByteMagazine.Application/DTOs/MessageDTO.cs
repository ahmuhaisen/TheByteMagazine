using System.ComponentModel.DataAnnotations;

namespace TheByteMagazine.Application.DTOs;
public class MessageDTO
{
    [MinLength(5)]
    [MaxLength(30)]
    public required string Name { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [MinLength(5)]
    [MaxLength(500)]
    public required string Body { get; set; }
}
