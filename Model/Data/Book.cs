public class Book
{
    public int BookID { get; set; }
    public string? Author { get; set; }
    public string? BookName { get; set; }
    public string? Genre { get; set; }
    public string? Year { get; set; }
    public string? Edition { get; set; }
    public string? Picture { get; set; }
    public string? Annotation { get; set; }
    public User? Owner { get; set; } 

    public Book() {}

    public Book(int bookid, string author, string genre, string year, string edition, string bookname, string picture, string annotation, User owner)
    {
        BookID = bookid;
        Author = author;
        Genre = genre;
        Year = year;
        Edition = edition;
        BookName = bookname;
        Picture = picture;
        Annotation = annotation;
        Owner = owner;
    }
}