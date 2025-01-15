using TheByteMagazine.Application.DTOs;
using TheByteMagazine.Domain;

namespace TheByteMagazine.Application.Abstractions;


public interface IIssuesService
{
    Task<IEnumerable<IssueShortInfo>> GetAllAsync();
    Task<IssueDTO> GetByIdAsync(int id);
    Task<IssueDTO> GetLatestAsync();

    Task<IEnumerable<IssueContributorDTO>> GetIssueTeamAsync(int issueId);
    Task<IEnumerable<IssueContributorDTO>> GetIssueTeamWithRoleAsync(int issueId, int roleId);
    Task<PaginatedList<IssueDTO>> GetIssuesPageAsync(int pageIndex, int pageSize);
    Task<IEnumerable<string>> GetLatest5IssuesCoverImagesAsync();
}
