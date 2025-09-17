using Application.Common.Interfaces;
using Domain.Library;
using MediatR;

namespace Application.Books.Commands;

public record UpdateBookCommand(Guid Id, string Title, string Description) : IRequest<Book?>;

public class UpdateBookCommandHandler(IBookService bookService) 
    : IRequestHandler<UpdateBookCommand, Book?>
{
    public Task<Book?> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var result = bookService.UpdateBook(request.Id, request.Title, request.Description);
        return Task.FromResult(result);
    }
}