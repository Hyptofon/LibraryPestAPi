using Api.Dtos;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("authors")]
[ApiController]
public class AuthorController(IAuthorService authorService) : ControllerBase
{

    [HttpGet]
    public ActionResult<IReadOnlyList<AuthorDto>> GetAuthors(CancellationToken cancellationToken)
    {
        var authors = authorService.GetAuthors();

        return authors.Select(AuthorDto.FromDomainModel).ToList();
    }

    [HttpPost]
    public ActionResult<AuthorDto> CreateAuthor(
        [FromBody] CreateAuthorDto request,
        CancellationToken cancellationToken)
    {
        var newAuthor = authorService.CreateAuthor(Guid.NewGuid(), request.Name);

        return AuthorDto.FromDomainModel(newAuthor);
    }
}