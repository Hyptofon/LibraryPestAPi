using System;
using System.Collections.Generic;
using Domain.Library;

namespace Application.Common.Interfaces
{
    public interface IBookService
    {
        Book CreateBook(Guid id, string title, string description, Guid authorId);
        Book? UpdateBook(Guid id, string title, string description);
        bool DeleteBook(Guid id);
        Book? GetBookById(Guid id);
        IReadOnlyList<Book> GetBooks();
    }
}