using Microsoft.AspNetCore.Mvc;
using nc_mvc.Services;

namespace nc_mvc.Controllers;

[ApiController]
[Route("/[controller]")]  // "/authors/..."
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
}
