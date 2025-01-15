using System;

namespace TheByteMagazine.Application.DTOs;


public class IssueDTO
{
    // Validate the properties using "DataAnnotations" (e.g. [MaxLength(number)]),
    // the constraints are in the entity configuration class (see IssuesConfig.cs)

    // Do I need the "Id" to be existed in the request?
    public int Id { get; set; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public byte Number { get; init; }

    public DateTime PublishedAt { get; init; }
    public required string FlipHtmlUrl { get; set; }
    public required string DirectorNote { get; set; }

    public required string CoverImageUrl { get; init; }
}
