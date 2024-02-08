using Data;
using lab3_app.Mappers;
using Microsoft.EntityFrameworkCore;

namespace lab3_app.Models;

public class EFReviewService : IReviewService
{
    private AppDbContext _context;
    public EFReviewService(AppDbContext context) => _context = context;

    public int Add(Review review)
    {
        var e = _context.Reviews.Add(ReviewMapper.ToEntity(review));
        _context.SaveChanges();
        return e.Entity.Id;
    }

    public void Delete(int id)
    {
        var find = _context.Reviews.Find(id);
        if (find == null) return;
        _context.Reviews.Remove(find);
        _context.SaveChanges();
    }

    public List<Review> FindAll()
    {
        return _context.Reviews.Select(e => ReviewMapper.FromEntity(e)).ToList();
    }

    public Review? FindById(int id)
    {
        return ReviewMapper.FromEntity(_context.Reviews.AsNoTracking().FirstOrDefault(r => r.Id == id));
    }
    
    public void Update(Review review)
    {
        _context.Reviews.Update(ReviewMapper.ToEntity(review));
        _context.SaveChanges();
    }
    
    public List<Review> FindAllByProductId(int productId)
    {
        return _context.Reviews
            .Where(r => r.ProductId == productId)
            .Select(e => ReviewMapper.FromEntity(e))
            .ToList();
    }
    
    
}