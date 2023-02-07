using LibraryBookServiceApi.AppServices;
using LibraryBookServiceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBookServiceApi.Controllers
{


[ApiController]
[Route("api/book")]
public class BookController : ControllerBase
{
    private readonly IBookService _iBookService;

    public BookController(IBookService iBookService)
    {
        _iBookService = iBookService;
    }

    [HttpGet("{id::int}")]
    public IActionResult GetMe(int id)
    {
        var book = _iBookService.GetBook(id);
        if (book == null)
            return NoContent();

        return Ok(book);
    }

    [HttpGet]
    public IActionResult All() => Ok(_iBookService.GetAllBooks());

    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        if (!ModelState.IsValid)
            return BadRequest("Input is not correct!");

        var addedBook =  _iBookService.AddBook(book);
        if (addedBook.Id < 1)
            return BadRequest("Date of publish must be in the past!");

        return Ok(addedBook);
    }

    [HttpPut]
    public IActionResult UpdateBook(Book newBook)
    {
        if (newBook.Id < 1)
            return BadRequest();

        return Ok(_iBookService.UpdateBook(newBook));
    }

    [HttpDelete("{id::int}")]
    public IActionResult RemoveBook(int id)
    {
        if (id < 0)
            return BadRequest();

        _iBookService.RemoveBook(id);
        return Ok("Book has been deleted successfully!");
    }
}
}