using Application.Common.Interfaces;
using MediatR;

namespace Application.Books.Commands;

public record DeleteBookCommand(Guid BookId) : IRequest<bool>;

public class DeleteBookCommandHandler(IBookService bookService) 
    : IRequestHandler<DeleteBookCommand, bool>
{
    public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var result = bookService.DeleteBook(request.BookId);
        return Task.FromResult(result);
    }
}