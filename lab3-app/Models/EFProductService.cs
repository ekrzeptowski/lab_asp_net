using Data;
using Data.Entities;
using lab3_app.Mappers;
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
            return _context.Products.Select(e => ProductMapper.FromEntity(e)).ToList();
        }

        public Product? FindById(int id)
        {
            return ProductMapper.FromEntity(_context.Products.Include(p => p.Reviews).ThenInclude(r => r.User).FirstOrDefault(p => p.Id == id));
        }

        public void Update(Product product)
        {
            _context.Products.Update(ProductMapper.ToEntity(product));
            _context.SaveChanges();
        }
    }
}
