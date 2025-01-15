using Microsoft.AspNetCore.Mvc;
using TheByteMagazine.Application.Abstractions;
using TheByteMagazine.Application.DTOs;
using TheByteMagazine.Domain;
using Microsoft.AspNetCore.OutputCaching;
using TheByteMagazine.WebAPI.Common;
using Microsoft.AspNetCore.Authorization;

namespace TheByteMagazine.WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
[ResponseCache(Duration = 15, VaryByQueryKeys = new string[] { "issueId" })]
public class IssuesController(IIssuesService _issuesService,
                              IArticlesService _articlesService,
                              ILogger<IssuesController> _logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            _logger.LogInformation($"[CURRENTLY IN]: {nameof(IssuesController)}.{nameof(GetAll)}...");
            var data = await _issuesService.GetAllAsync();
            _logger.LogInformation($"Successfully returned all issues");
            return Ok(ApiResult<IEnumerable<IssueShortInfo>>.Success(data));
        }
        catch (Exception ex)
        {
            _logger.LogError("[An Error Occurred while getting all Issues]\nError Message: {ex.Message}", ex.Message);
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }

    [HttpGet]
    [Route("{issueId:int}")]
    public async Task<IActionResult> GetValue(int issueId)
    {
        _logger.LogInformation($"[CURRENTLY IN]: {nameof(IssuesController)}.{nameof(GetValue)}...\nIssueId = {issueId}");

        try
        {
            var data = await _issuesService.GetByIdAsync(issueId);

            if (data is not null)
                return Ok(data);
            else
                return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }

    [HttpGet("latest/covers")]
    public async Task<IActionResult> GetLast5IssuesCoverImages()
    {
        try
        {
            var data = await _issuesService.GetLatest5IssuesCoverImagesAsync();
            return Ok(ApiResult<IEnumerable<string>>.Success(data));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }


    [HttpGet]
    [Route("latest")]
    public async Task<IActionResult> GetLatest()
    {
        try
        {
            var data = await _issuesService.GetLatestAsync();
            return Ok(ApiResult<IssueDTO>.Success(data));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }

    [HttpGet]
    [Route("{issueId:int}/team")]
    public async Task<IActionResult> GetIssueTeam(int issueId)
    {
        try
        {
            var data = await _issuesService.GetIssueTeamAsync(issueId);
            return Ok(ApiResult<IEnumerable<IssueContributorDTO>>.Success(data));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }

    [HttpGet]
    [Route("{issueId:int}/articles")]
    public async Task<IActionResult> GetIssueArticles(int issueId)
    {
        try
        {
            var data = await _articlesService.GetArticlesByIssueId(issueId);
            return Ok(ApiResult<IEnumerable<ArticleDTO>>.Success(data));

        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }

    [HttpGet]
    [Route("{issueId:int}/team/{roleId:int}")]
    [EndpointDescription("Get all volunteers for a certain issue with a specific role (e.g. Director, Contributing Writers, ...etc)")]
    public async Task<IActionResult> GetIssueTeamWithRole(int issueId, int roleId)
    {
        try
        {
            var data = await _issuesService.GetIssueTeamWithRoleAsync(issueId, roleId);

            if (data.Any())
                return Ok(ApiResult<IEnumerable<IssueContributorDTO>>.Success(data));

            return Ok(ApiResponse.Failure("No Contributions found"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ApiResponse.Failure($"Something went wrong, {ex.Message}"));
        }
    }
}
