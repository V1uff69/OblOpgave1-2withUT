namespace Bookshelf
{
    public class BooksRepository
    {
        // Initialize a list of books
        List<Book> bookList = new List<Book>
        {
            new Book("The Snowman", 420),
            new Book("Disney: Peter Plys", 123),
            new Book("Flip", 69),
            new Book("Kadavermarch", 88),
            new Book("Olelukøje", 1000)
        };



        public List<Book> Get(double? minPrice, double? maxPrice, bool sortByTitle)
        {
            List<Book> bookListCopy = new List<Book>();

            foreach (Book book in bookList)
            {
                if (minPrice == null && maxPrice == null || book.Price >= minPrice && book.Price <= maxPrice)
                {
                    Book copyBook = new Book(book.Title, book.Price);
                    bookListCopy.Add(copyBook);
                }
            }

            if (sortByTitle)
            {
                bookListCopy = bookListCopy.OrderBy(book => book.Title).ToList();
            }
            else
            {
                bookListCopy = bookListCopy.OrderBy(book => book.Price).ToList();
            }

            return bookListCopy;
        }
        public Book GetById(int Id)
        {
            foreach (Book book in bookList)
            {
                if (book.Id == Id)
                {
                    return book;
                }

            }
            return null;
        }

        public Book Add(Book book)
        {
            Book.NextId = bookList.Max(book => book.Id) + 1;
            book.Id = Book.NextId;
            bookList.Add(book);
            return book;
        }
        public Book Delete(int Id)
        {
            foreach (Book book in bookList)
            {
                if (book.Id == Id)
                {
                    Book deletedBook = book;
                    bookList.Remove(deletedBook);
                    return deletedBook;
                }
            }
            return null;
        }

        public Book Update(int Id, Book values)
        {
            foreach (Book book in bookList)
            {
                if (book.Id == Id)
                {
                    book.Title = values.Title;
                    book.Price = values.Price;

                    return book;
                }
            }
            return null;
        }
    }
}
