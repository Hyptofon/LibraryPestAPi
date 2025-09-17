using Application.Authors.Commands;
using Application.Common.Interfaces;
using Domain.Library;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("authors")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly ISender _sender;

    public AuthorsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<Author>> GetAuthors([FromServices] IAuthorService authorService)
    {
        var authors = authorService.GetAuthors();
        return Ok(authors);
    }

    [HttpPost]
    public async Task<ActionResult<Author>> CreateAuthor([FromBody] CreateAuthorCommand command)
    {
        var author = await _sender.Send(command);
        return Ok(author);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Author>> UpdateAuthor(Guid id, [FromBody] string name)
    {
        var author = await _sender.Send(new UpdateAuthorCommand(id, name));
        return Ok(author);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        await _sender.Send(new DeleteAuthorCommand(id));
        return NoContent();
    }
}