using Microsoft.AspNetCore.Mvc;
using nc_mvc.Services;

namespace nc_mvc.Controllers;

[ApiController]
[Route("/api/[controller]")]  // "/authors/..."
public class AuthorsController : Controller
{
    private readonly AuthorsService _authorsService;

    public AuthorsController(AuthorsService authorsService)
    {
        _authorsService = authorsService;
    }

    [HttpGet]  // "/"
    public ActionResult<List<Author>> GetAllAuthors()
    {
        List<Author>? authorList = _authorsService.GetAllAuthors();
        return Ok(authorList);
    }

    [HttpGet("{id}")] 

    public ActionResult<Author> GetAuthor(int id)
    {
        Author? author = _authorsService.GetAuthor(id);
        if (author == null)
        {
            return NotFound($"No Author Found in this Id: {id}");
        }
        return Ok(author);
    }


    [HttpPost]  

    public ActionResult<Author> AddAuthor(Author author)
    {
        Author? newAuthor = _authorsService.AddAuthor(author);
       
        return Created("",author);
    }

    [HttpDelete("{id}")]  
    public IActionResult DeleteAuthor(int id)
    {
        string status = _authorsService.DeleteAuthor(id);
        if (status == "Not Found")
        {
            return NotFound($"Author with id {id} Not Found");
        }
        return Ok(status);
    }
}
