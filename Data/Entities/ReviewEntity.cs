using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities;

[Table("reviews")]
public class ReviewEntity
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public IdentityUser User { get; set; }
    
}