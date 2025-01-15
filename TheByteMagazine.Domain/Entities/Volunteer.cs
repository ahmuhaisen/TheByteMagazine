namespace TheByteMagazine.Domain.Entities;


public class Volunteer : IEntity
{
    public int Id { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PersonalImagePath { get; set; }
    public string? LinkedInProfileUrl { get; set; }

    public ICollection<Contribution> Contributions { get; set; } = [];
}
