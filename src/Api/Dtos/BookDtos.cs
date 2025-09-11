namespace Api.Dtos;

public record BookDto(Guid Id, string Title, string Description, Guid AuthorId, DateTime CreatedAt, DateTime? UpdatedAt)
{
    public static BookDto FromDomainModel(Domain.Library.Book book)
        => new(book.Id, book.Title, book.Description, book.AuthorId, book.CreatedAt, book.UpdatedAt);
}

public record CreateBookDto(string Title, string Description, Guid AuthorId);