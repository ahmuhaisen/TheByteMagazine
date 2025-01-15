using TheByteMagazine.Application.DTOs;
using TheByteMagazine.Domain;

namespace TheByteMagazine.Application.Abstractions;

public interface IVolunteersService
{
    Task<IEnumerable<VolunteerDTO>> GetAllAsync();
    Task<VolunteerDTO> GetByIdAsync(int id);
    Task<VolunteerWithContributionsDTO> GetVolunteerWithContributionsByIdAsync(int id);
    Task<IEnumerable<VolunteerDTO>> GetTopContributorsAsync(int number);
    Task<PaginatedList<VolunteerDTO>> GetVolunteersPageAsync(int pageIndex, int pageSize);
}