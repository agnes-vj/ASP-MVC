using Microsoft.AspNetCore.Http.HttpResults;
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
    internal Author? AddAuthor(Author author)
    {
        List<Author>? authorList = FetchAllAuthors();
        int newId = authorList!.OrderByDescending(author => author.Id).FirstOrDefault()!.Id + 1;
        author.Id = newId;
        authorList.Add(author);
        File.WriteAllText("./Resources/Authors.json", JsonSerializer.Serialize(authorList));
        return author;
    }
    internal void DeleteAuthor(int authorId)
    {
        List<Author>? authorList = FetchAllAuthors();
        authorList.FindAll(author => author.Id == authorId).ForEach(authorToDelte => authorList.Remove(authorToDelte));
        File.WriteAllText("./Resources/Authors.json", JsonSerializer.Serialize(authorList));
    }

}
