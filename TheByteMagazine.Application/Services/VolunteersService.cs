using AutoMapper;
using TheByteMagazine.Application.Abstractions;
using TheByteMagazine.Application.DTOs;
using TheByteMagazine.Domain;
using TheByteMagazine.Infrastructure.Abstractions;

namespace TheByteMagazine.Application.Services;

public class VolunteersService(IVolunteersRepository _repo,
                               IMapper _mapper) : IVolunteersService
{
    public async Task<IEnumerable<VolunteerDTO>> GetAllAsync()
    {
        var allVolunteers = await _repo.GetAllAsync();

        if (allVolunteers is null)
            return Enumerable.Empty<VolunteerDTO>();

        var data = _mapper.Map<IEnumerable<VolunteerDTO>>(allVolunteers);

        return data;
    }

    public async Task<VolunteerDTO> GetByIdAsync(int id)
    {
        var volunteer = await _repo.GetByIdAsync(id);

        if (volunteer is null)
            return null!;

        var data = _mapper.Map<VolunteerDTO>(volunteer);

        return data;
    }

    public async Task<VolunteerWithContributionsDTO> GetVolunteerWithContributionsByIdAsync(int id)
    {
        var volunteer = await _repo.GetWithContributionsAsync(id);

        if (volunteer is null)
            return null!;

        var data = _mapper.Map<VolunteerWithContributionsDTO>(volunteer);

        return data;
    }

    public async Task<IEnumerable<VolunteerDTO>> GetTopContributorsAsync(int number)
    {
        var volunteers = await _repo.GetTopContributorsAsync(number);

        if (volunteers is null)
            return Enumerable.Empty<VolunteerDTO>();

        var data = _mapper.Map<IEnumerable<VolunteerDTO>>(volunteers);

        return data;
    }

    public async Task<PaginatedList<VolunteerDTO>> GetVolunteersPageAsync(int pageIndex, int pageSize)
    {
        var paginatedList = await _repo.GetPageAsync(pageIndex, pageSize, i => i.Id);

        var data = _mapper.Map<PaginatedList<VolunteerDTO>>(paginatedList);

        return data;
    }
}
