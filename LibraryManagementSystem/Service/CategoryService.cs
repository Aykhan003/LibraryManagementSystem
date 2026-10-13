using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Service;

public class CategoryService
{
    private readonly LibraryDbContext _context;
    public CategoryService(LibraryDbContext context)
    {
        _context = context;
    }
    public List<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }
    public Category GetCategoryById(int id)
    {
        return _context.Categories.FirstOrDefault(c => c.Id == id);
    }
    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }
    public void UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }
    public void DeleteCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
