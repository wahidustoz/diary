var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Misol uchun: xotira ichida ma'lumotlar bazasi
var books = new List<Entities.Book>
{
    new Entities.Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet", Price = 39.99M, PublishedDate = DateTime.Now }
};

// Mapper sozlash
var configuration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Entities.Book, Dtos.Book>();
    cfg.CreateMap<Models.Book, Entities.Book>();
});
var mapper = configuration.CreateMapper();

// Barcha kitoblarni olish (DTO shaklida)
app.MapGet("/books", () =>
{
    return books.Select(book => mapper.Map<Dtos.Book>(book));
});

// Yangi kitob qo'shish (Model orqali)
app.MapPost("/books", (Models.Book model) =>
{
    var newBook = mapper.Map<Entities.Book>(model);
    newBook.Id = books.Count + 1;
    newBook.PublishedDate = DateTime.Now;

    books.Add(newBook);
    return Results.Created($"/books/{newBook.Id}", newBook);
});

app.Run(); 