using TheByteMagazine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TheByteMagazine.Infrastructure.Abstractions;
using TheByteMagazine.Infrastructure.Data;

namespace TheByteMagazine.Infrastructure.Repositories;

public class VolunteersRepository : Repository<Volunteer>, IVolunteersRepository
{
    private readonly ApplicationDbContext _db;

    public VolunteersRepository(ApplicationDbContext db) : base(db) => _db = db;


    public async Task<Volunteer?> GetWithContributionsAsync(int id)
    {
        return await _db.Volunteers
            .AsNoTracking()
            .Include(x => x.Contributions)
                .ThenInclude(c => c.Issue)
            .Include(x => x.Contributions)
                .ThenInclude(c => c.RoleType)
            .FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<IEnumerable<Volunteer>> GetTopContributorsAsync(int number)
    {
        return await _db.Volunteers
            .AsNoTracking()
            .OrderByDescending(x => x.Contributions.Count())
            .Take(number)
            .ToListAsync();
    }
}
