using Application.Books.Commands;
using Application.Common.Interfaces;
using Domain.Library;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly ISender _sender;

    public BooksController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<Book>> GetBooks([FromServices] IBookService bookService)
    {
        var books = bookService.GetBooks();
        return Ok(books);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook([FromBody] CreateBookCommand command)
    {
        var book = await _sender.Send(command);
        return Ok(book);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Book>> UpdateBook(Guid id, [FromBody] UpdateBookCommand command)
    {
        var book = await _sender.Send(command with { Id = id });
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        await _sender.Send(new DeleteBookCommand(id));
        return NoContent();
    }
}