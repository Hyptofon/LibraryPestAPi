using Domain.Library;

namespace Application.Common.Interfaces;

public interface IBookService
{
    Book CreateBook(Guid id, string title, string description, Guid authorId);
    IReadOnlyList<Book> GetBooks();
}