using System.Text.Json;

namespace nc_mvc.Models
{
    public class BooksModel
    {
        public List<Book>? FetchAllBooks()
        {
            string booksJsonString = File.ReadAllText("./Resources/Books.json");
            List<Book>? booksList = JsonSerializer.Deserialize<List<Book>>(booksJsonString);
            return booksList;
        }
        internal Book? FetchBook(int id)
        {
            Book? book = FetchAllBooks()?.FirstOrDefault(book => book.Id == id);
            return book;

        }


        internal Book? AddBook(Book book)
        {
                string booksJsonString = File.ReadAllText("./Resources/Books.json");
                List<Book>? booksList = JsonSerializer.Deserialize<List<Book>>(booksJsonString);

                int maxBookId = booksList.OrderByDescending(books => books.Id).First().Id;
                int newBookid = maxBookId + 1;

                book.Id = newBookid;
                booksList.Add(book);

                File.WriteAllText("./Resources/Books.json", JsonSerializer.Serialize(booksList));

                return book;
        }

        internal string DeleteBook(int bookId)
        {

            List<Book>? books = FetchAllBooks();
            string status = "Not Found";
            int deleteCount = 0;
            books.FindAll(book => book.Id == bookId).ForEach(bookToDelete =>
            {
                books.Remove(bookToDelete);
                deleteCount++;
                status = $"{deleteCount} Records Deleted";
            });

            File.WriteAllText("./Resources/Books.json", JsonSerializer.Serialize(books));

            return status;
        }

    }
}
