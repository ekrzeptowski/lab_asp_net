using Data.Entities;
using lab3_app.Models;

namespace lab3_app.Mappers
{
    public class ProductMapper
    {
        public static Product FromEntity(ProductEntity entity)
        {
            return new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ProductionDate = entity.ProductionDate,
                Producent = entity.Producent,
                Category = entity.Category,
                CategoryId = entity.CategoryId,
                Reviews = entity.Reviews
            };
        }

        public static ProductEntity ToEntity(Product product)
        {
            return new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ProductionDate = product.ProductionDate,
                Producent = product.Producent,
                CategoryId = product.CategoryId
            };
        }
    }
}