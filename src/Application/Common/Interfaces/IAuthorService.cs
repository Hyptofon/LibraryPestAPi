using Domain.Library;

namespace Application.Common.Interfaces;

public interface IAuthorService
{
    Author CreateAuthor(Guid id, string name);
    IReadOnlyList<Author> GetAuthors();
    
}