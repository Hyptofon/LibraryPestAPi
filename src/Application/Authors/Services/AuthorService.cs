using Application.Common.Interfaces;
using Domain.Library;

namespace Application.Authors.Services;

public class AuthorService : IAuthorService
{
    private readonly List<Author> _authors = new();

    public Author CreateAuthor(Guid id, string name)
    {
        var author = Author.New(id, name);
        _authors.Add(author);
        return author;
    }

    public Author? UpdateAuthor(Guid id, string name)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id && !a.IsDeleted);
        author?.Rename(name);
        return author;
    }

    public bool DeleteAuthor(Guid id)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id && !a.IsDeleted);
        if (author == null) return false;
        author.Delete();
        return true;
    }

    public Author? GetAuthorById(Guid id)
        => _authors.FirstOrDefault(a => a.Id == id && !a.IsDeleted);

    public IReadOnlyList<Author> GetAuthors()
        => _authors.Where(a => !a.IsDeleted).ToList();
}