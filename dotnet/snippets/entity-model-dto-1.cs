/// <summary>
/// Ma'lumotlar bazasidagi Book jadvali uchun Entity.
/// </summary>
namespace Ilmhub.Api.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishedDate { get; set; }
} 