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

    internal Author? FetchAuthorByName(string authorName)
    {
        Author? author = FetchAllAuthors()?.FirstOrDefault(author => author.Name == authorName);
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
    internal string DeleteAuthor(int authorId)
    {
        List<Author>? authorList = FetchAllAuthors();
        string status = "Not Found";
        int deleteCount = 0;
        authorList.FindAll(author => author.Id == authorId).ForEach(authorToDelte =>
        {
            authorList.Remove(authorToDelte);
            deleteCount++;
            status = $"{deleteCount} Records Deleted";
        });
        File.WriteAllText("./Resources/Authors.json", JsonSerializer.Serialize(authorList));

        return status;
    }

}
