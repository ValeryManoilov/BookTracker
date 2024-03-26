using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
public class UserController : ControllerBase 
{
    private readonly IUserLibraryRepository _userRepository;

    public UserController(IUserLibraryRepository userRepository)
    {
        _userRepository = userRepository;
    }

    
    [HttpGet("/api/users/{UserID}/library")]
    public List<Book> GetAllBooksFromLib(int UserID)
    {
        return _userRepository.GetAllBooksFromLib(UserID);
    }

    [HttpPost("/api/users/add")]
    public void AddUser([FromBody] User user)
    {
        _userRepository.AddUser(user);
    }

    [HttpPost("/api/users/{UserID}/library/{BookID}")]
    public void AddBookToLib(int UserID, int BookID)
    {
        _userRepository.AddBookToLib(UserID, BookID);
    }

    [HttpDelete("/api/users/{userId}/library/{bookId}")]
    public void DeleteBookFromLib(int UserID, int BookID)
    {
        _userRepository.DeleteBookFromLib(UserID, BookID);
    }
}