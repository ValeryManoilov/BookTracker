public class UserTrackerRepository : IUserLibraryRepository
{
    private readonly BookAndUserTrackerContext _context;

    public UserTrackerRepository(BookAndUserTrackerContext context)
    {
        _context = context;
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    public List<Book> GetAllBooksFromLib(int UserID)
    {
        return _context.Users.FirstOrDefault(u => u.UserID == UserID).Library.ToList();
    }

    public void AddBookToLib(int UserID, int BookID)
    {
        var book = _context.Books.FirstOrDefault(b => b.BookID == BookID);
        _context.Users.FirstOrDefault(u => u.UserID == UserID).Library.Add(book);
        _context.SaveChanges();
    }

    public void DeleteBookFromLib(int UserID, int BookID)
    {
        var book = _context.Books.FirstOrDefault(b => b.BookID == BookID);
        _context.Users.FirstOrDefault(u => u.UserID == UserID).Library.Remove(book);
        _context.SaveChanges();
    }
}