namespace LibraryManagementSystem.Models;

public class Borrowing
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public DateTime BorrowDate
    {
        get { return field; }
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Borrowed date cannot be in the future.");
            }
            field = value;
        }
    }
    public DateTime DueDate
    {
        get { return field; }
        set
        {
            if (value < BorrowDate)
            {
                throw new ArgumentException("Due date cannot be earlier than borrowed date.");
            }
            field = value;
        }
    }
    public DateTime? ReturnDate
    {
        get { return field; }
        set
        {
            if (value.HasValue && value.Value < BorrowDate)
            {
                throw new ArgumentException("Return date cannot be earlier than borrowed date.");
            }
            field = value;
        }
    }
}
