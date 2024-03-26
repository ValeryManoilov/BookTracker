public interface IUserLibraryRepository
{
    List<Book> GetAllBooksFromLib(int UserID);

    void AddUser(User user);
    void AddBookToLib(int UserID, int BookID);
    void DeleteBookFromLib(int UserID, int BookID);
}