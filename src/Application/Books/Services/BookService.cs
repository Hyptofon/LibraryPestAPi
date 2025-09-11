using Application.Common.Interfaces;
using Domain.Library;

namespace Application.Books.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books = [];
    public Book CreateBook(Guid id, string title, string description, Guid authorId)
    {
        var book = Book.New(id, title, description, authorId);

        _books.Add(book);

        return book;
    }
    
    public IReadOnlyList<Book> GetBooks()
    {
        return _books;
    }
}