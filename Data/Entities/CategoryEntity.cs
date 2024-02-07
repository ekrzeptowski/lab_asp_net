using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("categories")]
public class CategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ISet<ProductEntity> Products { get; set; }
}