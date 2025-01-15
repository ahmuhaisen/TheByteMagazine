using TheByteMagazine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TheByteMagazine.Infrastructure.Abstractions;
using TheByteMagazine.Infrastructure.Data;

namespace TheByteMagazine.Infrastructure.Repositories;

public class ContributionsRepository : Repository<Contribution>, IContributionsRepository
{
    private readonly ApplicationDbContext _db;

    public ContributionsRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Contribution>> GetContributionsByIssueId(int issueId)
    {
        return await _db.Contributions
            .AsNoTracking()
            .Where(c => c.IssueId == issueId)
            .Include(c => c.Volunteer)
            .Include(c => c.RoleType)
            .ToListAsync();
    }

    public async Task<IEnumerable<Contribution>> GetContributionsByIssueIdAndRoleId(int issueId, int roleId)
    {
        return await _db.Contributions
            .AsNoTracking()
            .Where(c => c.IssueId == issueId && c.RoleTypeId == roleId)
            .Include(c => c.Volunteer)
            .Include(c => c.RoleType)
            .ToListAsync();
    }
}
