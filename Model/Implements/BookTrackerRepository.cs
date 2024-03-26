public class BookTrackerRepository : IBookRepository
{
    private readonly BookAndUserTrackerContext _context;

    public BookTrackerRepository(BookAndUserTrackerContext context)
    {
        _context = context;
    }

    public List<Book> GetAllBooks()
    {
        return _context.Books.ToList();
    }

    public Book GetBookByID(int BookID)
    {
        return _context.Books.FirstOrDefault(b => b.BookID == BookID);
    }


    public void AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void UpdateBook(int BookID, string NewAnnotation)
    {
        var book = _context.Books.FirstOrDefault(b => b.BookID == BookID);
        book.Annotation = NewAnnotation;
        _context.SaveChanges();
    }

    public void DeleteBook(int BookID)
    {
        var book = _context.Books.FirstOrDefault(b => b.BookID == BookID);
        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}