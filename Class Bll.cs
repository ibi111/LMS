using DAL;
using model;


namespace BLL
{
    class BookManager
    {
        public void AddBook(Book book)
        {
            BookRepository bookRepo = new BookRepository();
            bookRepo.AddBook(book);
        }

        public List<Book> GetAllBooks()
        {
            BookRepository bookRepo = new BookRepository();
            return bookRepo.GetAllBooks();
        }

        public Book? SearchBookByTitle(string bookTitle)
        {
            BookRepository bookRepo = new BookRepository();
            return bookRepo.SearchBookByTitle(bookTitle);
        }

        public void BorrowBook(int bookId)
        {
            BookRepository bookRepo = new BookRepository();
            bookRepo.BorrowBook(bookId);
        }

        public void ReturnBook(int bookId)
        {
            BookRepository bookRepo = new BookRepository();
            bookRepo.ReturnBook(bookId);
        }
    }
}
