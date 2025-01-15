using TheByteMagazine.Domain.Entities;

namespace TheByteMagazine.Infrastructure.Abstractions;

public interface IVolunteersRepository : IRepository<Volunteer>
{
    Task<Volunteer?> GetWithContributionsAsync(int id);
    Task<IEnumerable<Volunteer>> GetTopContributorsAsync(int number);
}
