using Microsoft.AspNetCore.Mvc;
using nc_mvc.Services;

namespace nc_mvc.Controllers;

[ApiController]
[Route("/api/[Controller]")]
public class BooksController : Controller
{
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService)
    {
        _booksService = booksService;
    }
    // GET: BooksController
    [HttpGet]
    public ActionResult<List<Book>?> GetAllBooks()
    {
        return Ok(_booksService.GetAllBooks());
    }

    [HttpGet("{id}")]
    public ActionResult<Book?> Details(int id)
    {
        Book book = _booksService.GetBook(id);
        if (book != null)
             return Ok(book);
        return NotFound("Book Not Found");
    }

    [HttpPost]
    public ActionResult<Book> AddBook(Book book)
    {
        Book bookAdded = _booksService.AddBook(book);
        if (bookAdded != null)
        {
            return Created();

        }
        return NotFound("Book is not Added, Author info not found for this book");        
    }

    [HttpDelete("{id}")]    
    public ActionResult<string> DeleteBook(int id)
    {
        string status = _booksService.DeleteBook(id);
        if (status == "Not Found")
        {
            return NotFound($"Book with id {id} Not Found");
        }
        return NoContent();
    }        
}
