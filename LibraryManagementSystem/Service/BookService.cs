using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Service;

public class BookService
{
    private readonly LibraryDbContext _context;
    
    public BookService(LibraryDbContext context)
    {
        _context = context;
    }
    public List<Book> GetAllBooks()
    {
        return _context.Books.ToList();
    }
    public Book GetBookById(int id)
    {
        return _context.Books.FirstOrDefault(b => b.Id == id);
    }
    public void AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }
    public void UpdateBook(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
    }
    public void DeleteBook(int id)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
    public List<Book> SearchBooks(string searchTerm)
    {
        return _context.Books
            .Where(b => b.Title.Contains(searchTerm) || b.Author.FullName.Contains(searchTerm) || b.Category.Name.Contains(searchTerm))
            .ToList();
    }
    public List<Book> GetBooksByAuthor(int authorId)
    {
        return _context.Books.Where(b => b.AuthorId == authorId).ToList();
    }
    public List<Book> GetBooksByCategory(int categoryId)
    {
        return _context.Books.Where(b => b.CategoryId == categoryId).ToList();
    }
}
