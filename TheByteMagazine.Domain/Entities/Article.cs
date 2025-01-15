namespace TheByteMagazine.Domain.Entities;


public class Article : IEntity
{
    public int Id { get; set; }

    public required string Title { get; set; }
    public int PageNumber { get; set; }

    public int IssueId { get; set; }
    public required Issue Issue { get; set; }
}