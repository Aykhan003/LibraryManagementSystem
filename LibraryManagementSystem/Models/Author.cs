namespace LibraryManagementSystem.Models;

public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate
    {
        get { return field; }
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Birth date cannot be in the future.");
            }
            field = value;
        }
    }
    public string Country { get; set; }
}
