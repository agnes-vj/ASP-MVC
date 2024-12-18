using System.Text.Json;

namespace nc_mvc.Models;

public class AuthorsModel
{
    public List<Author>? FetchAllAuthors()
    {
        string authorsJsonString = File.ReadAllText("./Resources/Authors.json");
        List<Author>? authorsList = JsonSerializer.Deserialize<List<Author>>(authorsJsonString);
        return authorsList;
    }

    internal Author? FetchAuthor(int id)
    {
        Author? author = FetchAllAuthors()?.FirstOrDefault(author => author.Id == id);
        return author;
    }
}
