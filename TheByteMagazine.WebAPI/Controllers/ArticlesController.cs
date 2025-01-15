using Microsoft.AspNetCore.Mvc;
using TheByteMagazine.Application.DTOs;
using TheByteMagazine.Application.Abstractions;
using TheByteMagazine.WebAPI.Common;

namespace TheByteMagazine.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticlesController(IArticlesService _articlesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(int issueId)
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
}
