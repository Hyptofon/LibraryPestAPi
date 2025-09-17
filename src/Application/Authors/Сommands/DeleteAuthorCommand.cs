using MediatR;
using Application.Common.Interfaces; 

namespace Application.Authors.Commands;

public record DeleteAuthorCommand(Guid AuthorId) : IRequest<bool>;

public class DeleteAuthorCommandHandler(IAuthorService authorService) 
    : IRequestHandler<DeleteAuthorCommand, bool>
{
    public Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var result = authorService.DeleteAuthor(request.AuthorId);
        return Task.FromResult(result);
    }
}