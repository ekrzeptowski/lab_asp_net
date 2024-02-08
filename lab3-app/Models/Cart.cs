using Microsoft.AspNetCore.Identity;

namespace lab3_app.Models;

public class Cart
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public string UserId { get; set; }

    public Product Product { get; set; }
    public IdentityUser User { get; set; }
}