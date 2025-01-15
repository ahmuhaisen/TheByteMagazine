namespace TheByteMagazine.Application.DTOs;

public record IssueContributorDTO
{
    public IssueContributorDTO(string fullName, string personalImageUrl, string linkedInProfileUrl, string role)
    {
        FullName = fullName;
        PersonalImageUrl = personalImageUrl;
        LinkedInProfileUrl = linkedInProfileUrl;
        Role = role;
    }

    public string FullName { get; init; }
    public string PersonalImageUrl { get; init; }
    public string LinkedInProfileUrl { get; init; }
    public string Role { get; init; }
}
