using AutoMapper;
using TheByteMagazine.Application.Abstractions;
using TheByteMagazine.Application.DTOs;
using TheByteMagazine.Infrastructure.Abstractions;

namespace TheByteMagazine.Application.Services;


public class ArticlesServices(IArticlesRepository _repo, IMapper _mapper) : IArticlesService
{
    public async Task<IEnumerable<ArticleDTO>> GetArticlesByIssueId(int issueId)
    {
        var articles = await _repo.GetAsync(a => a.IssueId == issueId);

        if (articles is null)
            return Enumerable.Empty<ArticleDTO>();

        var result = _mapper.Map<IEnumerable<ArticleDTO>>(articles);

        return result;
    }
}
