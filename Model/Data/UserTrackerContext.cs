using Microsoft.EntityFrameworkCore;

public class BookAndUserTrackerContext : DbContext
{
    public BookAndUserTrackerContext(DbContextOptions<BookAndUserTrackerContext> options) : base(options) {}

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(b => b.BookID);
        modelBuilder.Entity<User>().HasMany(u => u.Library).WithOne(b => b.Owner);
    }
}