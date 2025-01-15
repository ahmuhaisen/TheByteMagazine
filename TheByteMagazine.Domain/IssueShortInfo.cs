namespace TheByteMagazine.Domain;


public class IssueShortInfo
{
    public int Id { get; set; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public int Number { get; init; }
    public DateTime PublishedAt { get; init; }
    public required string CoverImageUrl { get; init; }
}