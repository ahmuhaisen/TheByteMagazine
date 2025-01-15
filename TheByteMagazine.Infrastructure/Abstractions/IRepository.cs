using TheByteMagazine.Domain;
using System.Linq.Expressions;

namespace TheByteMagazine.Infrastructure.Abstractions;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);
    Task<PaginatedList<T>> GetPageAsync<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderByTerm);

    Task<int> CreateAsync(T item);
}
