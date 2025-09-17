using Domain.Library;
using MediatR;
using Application.Common.Interfaces; 

namespace Application.Authors.Commands;

public record CreateAuthorCommand(string Name) : IRequest<Author>;

public class CreateAuthorCommandHandler(IAuthorService authorService) 
    : IRequestHandler<CreateAuthorCommand, Author>
{
    public Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = authorService.CreateAuthor(Guid.NewGuid(), request.Name);
        return Task.FromResult(author);
    }
}