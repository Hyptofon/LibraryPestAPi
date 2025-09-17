using Application.Common.Interfaces;
using Domain.Library;

namespace Application.Books.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books = new();
    private readonly IAuthorService _authorService;

    public BookService(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public Book CreateBook(Guid id, string title, string description, Guid authorId)
    {
        var author = _authorService.GetAuthorById(authorId);
        if (author == null || author.IsDeleted)
            throw new InvalidOperationException("Автор не існує або був видалений.");

        var book = Book.New(id, title, description, authorId);
        _books.Add(book);
        return book;
    }

    public Book? UpdateBook(Guid id, string title, string description)
    {
        var book = _books.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
        book?.UpdateBook(title, description);
        return book;
    }

    public bool DeleteBook(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
        if (book == null) return false;
        book.Delete();
        return true;
    }

    public Book? GetBookById(Guid id)
        => _books.FirstOrDefault(b => b.Id == id && !b.IsDeleted);

    public IReadOnlyList<Book> GetBooks()
        => _books.Where(b => !b.IsDeleted).ToList();
}