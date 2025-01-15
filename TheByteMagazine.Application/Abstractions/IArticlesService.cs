using TheByteMagazine.Application.DTOs;

namespace TheByteMagazine.Application.Abstractions;


public interface IArticlesService
{
    Task<IEnumerable<ArticleDTO>> GetArticlesByIssueId(int issueId);
}
