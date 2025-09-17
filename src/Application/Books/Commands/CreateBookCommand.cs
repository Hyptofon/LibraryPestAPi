using Application.Common.Interfaces;
using Domain.Library;
using MediatR;

namespace Application.Books.Commands;

public record CreateBookCommand(string Title, string Description, Guid AuthorId) : IRequest<Book>;

public class CreateBookCommandHandler(IBookService bookService) 
    : IRequestHandler<CreateBookCommand, Book>
{
    public Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var result = bookService.CreateBook(Guid.NewGuid(), request.Title, request.Description, request.AuthorId);
        return Task.FromResult(result);
    }
}