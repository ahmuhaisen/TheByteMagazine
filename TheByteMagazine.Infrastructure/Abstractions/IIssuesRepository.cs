using TheByteMagazine.Domain;
using TheByteMagazine.Domain.Entities;

namespace TheByteMagazine.Infrastructure.Abstractions;

public interface IIssuesRepository : IRepository<Issue>
{
    Task<IEnumerable<IssueShortInfo>> GetAllShortAsync();
    Task<Issue?> LatestAsync();
    Task<IEnumerable<string>> Latest5CoverImagesAsync();
}

