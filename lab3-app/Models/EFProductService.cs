using Data;
using Data.Entities;
using lab3_app.Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lab3_app.Models
{
    public class EFProductService : IProductService
    {
        private AppDbContext _context;
        public EFProductService(AppDbContext context) => _context = context;

        public int Add(Product product)
        {
            var e = _context.Products.Add(ProductMapper.ToEntity(product));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            ProductEntity? find = _context.Products.Find(id);
            if (find != null)
            {
                _context.Products.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Product> FindAll()
        {
            var products = _context.Products.Include(p => p.Reviews).Select(e => ProductMapper.FromEntity(e)).ToList();
            foreach (var product in products)
            {
                product.AverageReview = product.Reviews.Count > 0 ? product.Reviews.Select(r => r.Rating).Average() : 0;
                product.ReviewCount = product.Reviews.Count;
            }
            return products;
        }

        public Product? FindById(int id)
        {
            return ProductMapper.FromEntity(_context.Products.Include(p => p.Category).Include(p => p.Reviews)
                .ThenInclude(r => r.User).AsNoTracking().FirstOrDefault(p => p.Id == id));
        }

        public void Update(Product product)
        {
            _context.Products.Update(ProductMapper.ToEntity(product));
            _context.SaveChanges();
        }

        public int AddReview(Review review)
        {
            var e = _context.Reviews.Add(ReviewMapper.ToEntity(review));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void DeleteReview(int id)
        {
            var find = _context.Reviews.Find(id);
            if (find == null) return;
            _context.Reviews.Remove(find);
            _context.SaveChanges();
        }

        public List<Review> FindAllReviews()
        {
            return _context.Reviews.Select(e => ReviewMapper.FromEntity(e)).ToList();
        }

        public List<SelectListItem> FindAllCategoriesForViewModel()
        {
            return _context.Categories
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name })
                .ToList();
        }
    }
}