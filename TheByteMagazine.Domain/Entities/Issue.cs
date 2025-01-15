namespace TheByteMagazine.Domain.Entities;

public class Issue : IEntity
{
    public int Id { get; set; }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public int Number { get; set; }
    public DateTime PublishedAt { get; set; }
    public required string CoverImageUrl { get; set; }
    public required string FlipHtmlUrl { get; set; } = "UNKNOWN";
    public required string DirectorNote { get; set; } = "UNKNOWN";

    public ICollection<Contribution> Contributions { get; set; } = [];
}