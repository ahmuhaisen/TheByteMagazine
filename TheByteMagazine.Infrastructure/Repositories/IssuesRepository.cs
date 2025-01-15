using TheByteMagazine.Domain;
using TheByteMagazine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TheByteMagazine.Infrastructure.Abstractions;
using TheByteMagazine.Infrastructure.Data;


namespace TheByteMagazine.Infrastructure.Repositories;
public class IssuesRepository : Repository<Issue>, IIssuesRepository
{
    private readonly ApplicationDbContext _db;

    public IssuesRepository(ApplicationDbContext db) : base(db) => _db = db;

    public async Task<IEnumerable<IssueShortInfo>> GetAllShortAsync()
    {
        return await _db.Issues
            .AsNoTracking()
            .OrderByDescending(x => x.PublishedAt)
            .Select(i => new IssueShortInfo
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description,
                PublishedAt = i.PublishedAt,
                Number = i.Number,
                CoverImageUrl = i.CoverImageUrl,
            })
            .ToListAsync();
    }

    public async Task<Issue?> LatestAsync()
    {
        return await _db.Issues
            .AsNoTracking()
            .OrderByDescending(x => x.PublishedAt)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<string>> Latest5CoverImagesAsync()
    {
        return await _db.Issues
            .AsNoTracking()
            .OrderByDescending(x => x.PublishedAt)
            .Take(5)
            .Select(issue => issue.CoverImageUrl)
            .ToListAsync();
    }
}
