using Microsoft.EntityFrameworkCore; 
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddSingleton<IBookRepository>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<BookAndUserTrackerContext>();
    optionsBuilder.UseSqlite("Data Source=TaskDataBase.db"); 
    var BookAndUserContext = new BookAndUserTrackerContext(optionsBuilder.Options);
    BookAndUserContext.Database.EnsureCreated(); 
    IBookRepository BookRepository = new BookTrackerRepository(BookAndUserContext);

    return BookRepository;
});

builder.Services.AddSingleton<IUserLibraryRepository>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<BookAndUserTrackerContext>();
    optionsBuilder.UseSqlite("Data Source=TaskDataBase.db"); 
    var BookAndUserContext = new BookAndUserTrackerContext(optionsBuilder.Options);
    BookAndUserContext.Database.EnsureCreated(); 
    IUserLibraryRepository UserRepository = new UserTrackerRepository(BookAndUserContext);

    return UserRepository;
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();