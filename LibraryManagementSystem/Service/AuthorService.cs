using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Service;

public class AuthorService
{
    private readonly LibraryDbContext _context;

    public AuthorService(LibraryDbContext context)
    {
        _context = context;
    }
    public List<Author> GetAllAuthors()
    {
        return _context.Authors.ToList();
    }
    public Author GetAuthorById(int id)
    {
        return _context.Authors.FirstOrDefault(a => a.Id == id);
    }
    public void AddAuthor(Author author)
    {
        _context.Authors.Add(author);
        _context.SaveChanges();
    }
    public void UpdateAuthor(Author author)
    {
        _context.Authors.Update(author);
        _context.SaveChanges();
    }
    public void DeleteAuthor(int id)
    {
        var author = _context.Authors.FirstOrDefault(a => a.Id == id);
        if (author != null)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
    public List<Author> SearchAuthors(string searchTerm)
    {
        return _context.Authors
            .Where(a => a.FullName.Contains(searchTerm) || a.Country.Contains(searchTerm))
            .ToList();
    }
}
