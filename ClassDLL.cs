using System.IO;
using model;

namespace DAL
{
    class BookRepository
    {
        static string path = "myLibrarymanagementsystem.txt";

        // 1. create new book and save into db
        public void AddBook(Book book)
        {
            int bookId = IdGenerator.GenerateUniqueId();
            book.BookId = bookId;
            try
            {
                string bookDetails = $"{book.BookId},{book.BookTitle},{book.BookAuthor},{book.PublicationYear},{book.BookGenre},{book.BookStatus}";
                SaveBookToFile(bookDetails, true);
                Console.WriteLine("Book added successfully");
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        // 2. get all books from db
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] bookDetails = line.Split(',');
                    Book book = new Book(int.Parse(bookDetails[0]), bookDetails[1], bookDetails[2], int.Parse(bookDetails[3]), bookDetails[4], int.Parse(bookDetails[5]));
                    books.Add(book);
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
            return books;
        }

        // 3. search book by title
        public Book? SearchBookByTitle(string bookTitle)
        {
            Book? book = null;
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] bookDetails = line.Split(',');
                    if (bookDetails[1].Equals(bookTitle))
                    {
                        book = new Book(int.Parse(bookDetails[0]), bookDetails[1], bookDetails[2], int.Parse(bookDetails[3]), bookDetails[4], int.Parse(bookDetails[5]));
                        break;
                    }
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
            return book;
        }

        // 4. search book by author
        public Book? SearchBookByAuthor(string bookAuthor)
        {
            Book? book = null;
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] bookDetails = line.Split(',');
                    if (bookDetails[2] == bookAuthor)
                    {
                        book = new Book(int.Parse(bookDetails[0]), bookDetails[1], bookDetails[2], int.Parse(bookDetails[3]), bookDetails[4], int.Parse(bookDetails[5]));
                        break;
                    }
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
            return book;
        }

        // 5. Borrow book for a user
        public void BorrowBook(int bookId)
        {
            // get all books
            List<Book> books = GetAllBooks();
            // find book by id
            Book? book = books.Find(b => b.BookId == bookId);
            // if book is not found, print book not found
            if (book == null)
            {
                System.Console.WriteLine("Book not found");
                return;
            }
            // if book is found, check if book is already borrowed
            if (book.BookStatus == 1)
            {
                System.Console.WriteLine("Book is already borrowed");
                return;


            }
        }
    }

    class IdGenerator
    {
        private static int idCounter = 0;

        public static int GenerateUniqueId()
        {
            int currentSeconds = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            int uniqueId = currentSeconds + idCounter;
            idCounter++;
            return uniqueId;
        }
    }

}
