using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
public class BookController : ControllerBase 
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet("/api/books")]
    public IEnumerable<Book> GetAllBooks()
    {
        return _bookRepository.GetAllBooks();
    }
    
    [HttpGet("/api/books/{BookID}")]
    public Book GetBookByID(int BookID)
    {
        return _bookRepository.GetBookByID(BookID);
    }

    [HttpPost("/api/books")]
    public void AddBook([FromBody] Book book)
    {
        _bookRepository.AddBook(book);
    }

    [HttpPut("/api/books/{BookID}")]
    public void UpdateBook(int BookID, string NewAnnotation)
    {
        _bookRepository.UpdateBook(BookID, NewAnnotation);
    }

    [HttpDelete("/api/books/{BookID}")]
    public void DeleteBook(int BookID)
    {
        _bookRepository.DeleteBook(BookID);
    }

}