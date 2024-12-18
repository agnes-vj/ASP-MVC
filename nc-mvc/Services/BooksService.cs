using nc_mvc.Models;

namespace nc_mvc.Services
{
    public class BooksService
    {
        private readonly BooksModel _booksModel;

        public BooksService(BooksModel booksModel)
        {
            _booksModel = booksModel;
        }

        public List<Book>? GetAllBooks()
        {
            return _booksModel.FetchAllBooks();
        }
        public Book? GetBook(int id)
        {
            return _booksModel.FetchBook(id);
        }

        public Book? AddBook(Book book)
        {
            string newAuthor = book.Author;

            bool authorExists = new AuthorsModel().FetchAuthorByName(newAuthor) == null ? false : true;
            if (authorExists)
            {
                return _booksModel.AddBook(book);
            }
            return null;
        }
        public string DeleteBook(int bookId)
        {
            return _booksModel.DeleteBook(bookId);
        }
    }
}
