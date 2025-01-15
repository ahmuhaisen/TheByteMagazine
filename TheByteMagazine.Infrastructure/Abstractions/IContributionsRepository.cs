using TheByteMagazine.Domain.Entities;

namespace TheByteMagazine.Infrastructure.Abstractions;

public interface IContributionsRepository : IRepository<Contribution>
{
    Task<IEnumerable<Contribution>> GetContributionsByIssueId(int issueId);
    Task<IEnumerable<Contribution>> GetContributionsByIssueIdAndRoleId(int issueId, int roleId);
}