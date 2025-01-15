using TheByteMagazine.Domain.Entities;
using TheByteMagazine.Infrastructure.Abstractions;
using TheByteMagazine.Infrastructure.Data;

namespace TheByteMagazine.Infrastructure.Repositories;


public class ArticlesRepository : Repository<Article>, IArticlesRepository
{
    private readonly ApplicationDbContext _db;

    public ArticlesRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
}
