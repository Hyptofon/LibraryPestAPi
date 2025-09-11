using Api.Dtos;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[Route("books")]
[ApiController]
public class BookController(IBookService bookService) : ControllerBase
{

    [HttpGet]
    public ActionResult<IReadOnlyList<BookDto>> GetBooks(CancellationToken cancellationToken)
    {
        var books = bookService.GetBooks();

        return books.Select(BookDto.FromDomainModel).ToList();
    }

    [HttpPost]
    public ActionResult<BookDto> CreateBook(
        [FromBody] CreateBookDto request,
        CancellationToken cancellationToken)
    {
        var newBook = bookService.CreateBook(Guid.NewGuid(), request.Title, request.Description, request.AuthorId);

        return BookDto.FromDomainModel(newBook);
    }
}