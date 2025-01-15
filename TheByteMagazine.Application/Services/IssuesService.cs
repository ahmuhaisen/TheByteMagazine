using AutoMapper;
using TheByteMagazine.Application.Abstractions;
using TheByteMagazine.Application.DTOs;
using TheByteMagazine.Application.Helpers;
using TheByteMagazine.Domain;
using TheByteMagazine.Infrastructure.Abstractions;

namespace TheByteMagazine.Application.Services;


public class IssuesService(IIssuesRepository _repo,
                           IContributionsRepository _contributionRepo,
                           IMapper _mapper) : IIssuesService
{
    public async Task<IEnumerable<IssueShortInfo>> GetAllAsync()
    {
        var allIssues = await _repo.GetAllShortAsync();

        if (allIssues is null)
            return Enumerable.Empty<IssueShortInfo>();

        var data = allIssues.Select(i => new IssueShortInfo
        {
            Id = i.Id,
            Title = i.Title,
            Description = i.Description,
            PublishedAt = i.PublishedAt,
            Number = i.Number,
            CoverImageUrl = FileManager.IssuesCoverImagesPath + "/" + i.CoverImageUrl,
        });

        return data;
    }

    public async Task<IssueDTO> GetByIdAsync(int id)
    {
        var issue = await _repo.GetByIdAsync(id);

        if (issue is null)
            return null!;

        var data = _mapper.Map<IssueDTO>(issue);

        return data;
    }

    public async Task<IssueDTO> GetLatestAsync()
    {
        var latest = await _repo.LatestAsync();

        if (latest is null)
            return null!;

        var data = _mapper.Map<IssueDTO>(latest);

        return data;
    }

    public async Task<IEnumerable<string>> GetLatest5IssuesCoverImagesAsync()
    {
        var imagesIds = await _repo.Latest5CoverImagesAsync();
        return imagesIds.Select(image => $"{FileManager.IssuesCoverImagesPath}/{image}");
    }



    public async Task<IEnumerable<IssueContributorDTO>> GetIssueTeamAsync(int issueId)
    {
        var contributions = await _contributionRepo.GetContributionsByIssueId(issueId);

        if (contributions is null || !contributions.Any())
            return Enumerable.Empty<IssueContributorDTO>();

        var data = _mapper.Map<IEnumerable<IssueContributorDTO>>(contributions);

        return data;
    }

    public async Task<IEnumerable<IssueContributorDTO>> GetIssueTeamWithRoleAsync(int issueId, int roleId)
    {
        var contributions = await _contributionRepo.GetContributionsByIssueIdAndRoleId(issueId, roleId);

        if (contributions is null || !contributions.Any())
            return Enumerable.Empty<IssueContributorDTO>();

        var data = _mapper.Map<IEnumerable<IssueContributorDTO>>(contributions);

        return data;
    }

    public async Task<PaginatedList<IssueDTO>> GetIssuesPageAsync(int pageIndex, int pageSize)
    {
        var paginatedList = await _repo.GetPageAsync(pageIndex, pageSize, i => i.PublishedAt);

        var data = _mapper.Map<PaginatedList<IssueDTO>>(paginatedList);

        return data;
    }
}
