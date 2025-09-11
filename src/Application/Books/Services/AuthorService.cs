using Application.Common.Interfaces;
using Domain.Library;

namespace Application.Books.Services;

public class AuthorService : IAuthorService
{
    private readonly List<Author> _authors = [];
    public Author CreateAuthor(Guid id, string name)
    {
        var author = Author.New(id, name);

        _authors.Add(author);

        return author;
    }
    
    public IReadOnlyList<Author> GetAuthors()
    {
        return _authors;
    }
}