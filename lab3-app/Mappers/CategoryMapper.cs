using Data.Entities;
using lab3_app.Models;

namespace lab3_app.Mappers;

public class CategoryMapper
{
    public static Category FromEntity(CategoryEntity entity)
    {
        return new Category
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Products = entity.Products
        };
    }

    public static CategoryEntity ToEntity(Category category)
    {
        return new CategoryEntity
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
        };
    }
}