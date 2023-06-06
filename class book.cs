namespace model
{
    class Book
    {
        private int bookId;
        public int BookId { get { return bookId; } set { bookId = value; } }

        private string bookTitle;
        public string BookTitle { get { return bookTitle; } set { bookTitle = value; } }

        private string bookAuthor;
        public string BookAuthor { get { return bookAuthor; } set { bookAuthor = value; } }

        private int publicationYear;
        public int PublicationYear { get { return publicationYear; } set { publicationYear = value; } }

        private string bookGenre;
        public string BookGenre { get { return bookGenre; } set { bookGenre = value; } }

        private int bookStatus;
        public int BookStatus { get { return bookStatus; } set { bookStatus = value; } }

        public Book(int id, string title, string author, int year, string genre, int status = 0)
        {
            bookId = id;
            bookTitle = title;
            bookAuthor = author;
            publicationYear = year;
            bookGenre = genre;
            bookStatus = status;
        }
    }
}
