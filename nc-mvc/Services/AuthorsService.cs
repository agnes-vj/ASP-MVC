using nc_mvc.Models;

namespace nc_mvc.Services;

public class AuthorsService
{
    private readonly AuthorsModel _authorsModel;

    public AuthorsService(AuthorsModel authorsModel)
    {
        _authorsModel = authorsModel;
    }

    public List<Author>? GetAllAuthors()
    {
        return _authorsModel.FetchAllAuthors();
    }
}
