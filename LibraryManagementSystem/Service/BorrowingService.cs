using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Service;

public class BorrowingService
{
    private readonly LibraryDbContext _context;
    public BorrowingService(LibraryDbContext context)
    {
        _context = context;
    }
    public List<Borrowing> GetAllBorrowings()
    {
        return _context.Borrowings.ToList();
    }
    public Borrowing GetBorrowingById(int id)
    {
        return _context.Borrowings.FirstOrDefault(b => b.Id == id);
    }
    public void AddBorrowing(Borrowing borrowing)
    {
        _context.Borrowings.Add(borrowing);
        _context.SaveChanges();
    }
    public void UpdateBorrowing(Borrowing borrowing)
    {
        _context.Borrowings.Update(borrowing);
        _context.SaveChanges();
    }
    public void DeleteBorrowing(int id)
    {
        var borrowing = _context.Borrowings.FirstOrDefault(b => b.Id == id);
        if (borrowing != null)
        {
            _context.Borrowings.Remove(borrowing);
            _context.SaveChanges();
        }
    }
    public List<Borrowing> GetBorrowingsByMember(int memberId)
    {
        return _context.Borrowings.Where(b => b.MemberId == memberId).ToList();
    }
    public List<Borrowing> GetBorrowingsByBook(int bookId)
    {
        return _context.Borrowings.Where(b => b.BookId == bookId).ToList();
    }
}
