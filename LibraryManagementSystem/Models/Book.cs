namespace LibraryManagementSystem.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedYear
    {
        get { return field; }
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Publication date cannot be in the future.");
            }
            field = value;
        }
    }
    public decimal Price { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
