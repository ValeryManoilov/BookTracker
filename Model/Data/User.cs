using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class User
{
    public int UserID { get; set; }
    public string? Username { get; set; }
    public List<Book>? Library { get; set; }

    public User() { }
    
    public User(int userid, string username, List<Book> library)
    {
        UserID = userid;
        Username = username;
        Library = library;
    }
}