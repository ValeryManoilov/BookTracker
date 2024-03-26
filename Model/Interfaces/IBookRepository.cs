public interface IBookRepository
{
    List<Book> GetAllBooks();
    Book GetBookByID(int BookID);

    void AddBook(Book book);
    void UpdateBook(int BookID, string NewAnnotation);
    void DeleteBook(int BookID);
}