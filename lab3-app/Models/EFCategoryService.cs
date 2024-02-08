using System.Data.Entity;
using Data;
using Data.Entities;
using lab3_app.Mappers;

namespace lab3_app.Models;

public class EFCategoryService : ICategoryService
{
    private AppDbContext _context;
    public EFCategoryService(AppDbContext context) => _context = context;

    public int Add(Category category)
    {
        var e = _context.Categories.Add(CategoryMapper.ToEntity(category));
        _context.SaveChanges();
        return e.Entity.Id;
    }

    public void Delete(int id)
    {
        CategoryEntity? find = _context.Categories.Find(id);
        if (find != null)
        {
            _context.Categories.Remove(find);
            _context.SaveChanges();
        }
    }

    public List<Category> FindAll()
    {
        return _context.Categories.Include(c => c.Products).AsNoTracking().Select(e => CategoryMapper.FromEntity(e)).ToList();
    }

    public Category? FindById(int id)
    {
        return CategoryMapper.FromEntity(_context.Categories.FirstOrDefault(c => c.Id == id));
    }

    public void Update(Category category)
    {
        _context.Categories.Update(CategoryMapper.ToEntity(category));
        _context.SaveChanges();
    }
}