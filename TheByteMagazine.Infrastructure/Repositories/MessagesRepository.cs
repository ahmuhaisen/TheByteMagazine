using TheByteMagazine.Domain.Entities;
using TheByteMagazine.Infrastructure.Abstractions;
using TheByteMagazine.Infrastructure.Data;


namespace TheByteMagazine.Infrastructure.Repositories;

public class MessagesRepository : Repository<Message>, IMessagesRepository
{
    private readonly ApplicationDbContext _db;

    public MessagesRepository(ApplicationDbContext db) : base(db) => _db = db;
}
