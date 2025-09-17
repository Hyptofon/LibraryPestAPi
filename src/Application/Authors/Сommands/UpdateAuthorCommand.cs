using Domain.Library;
using MediatR;
using Application.Common.Interfaces; 

namespace Application.Authors.Commands;

public record UpdateAuthorCommand(Guid AuthorId, string Name) : IRequest<Author?>;

public class UpdateAuthorCommandHandler(IAuthorService authorService) 
    : IRequestHandler<UpdateAuthorCommand, Author?>
{
    public Task<Author?> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var result = authorService.UpdateAuthor(request.AuthorId, request.Name);
        return Task.FromResult(result);
    }
}