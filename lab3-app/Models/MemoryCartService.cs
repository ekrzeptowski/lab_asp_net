namespace lab3_app.Models;

public class MemoryCartService : ICartService
{
    private List<Cart> _carts = new List<Cart>();
    private int _nextId = 1;

    public int Add(Product product, int quantity, string userId)
    {
        var cart = new Cart
        {
            Id = _nextId++,
            Product = product,
            Quantity = quantity,
            UserId = userId
        };
        _carts.Add(cart);
        return cart.Id;
    }

    public void Delete(int id)
    {
        _carts.RemoveAll(c => c.Id == id);
    }
    
    public void ClearCartByUser(string userId)
    {
        _carts.RemoveAll(c => c.UserId == userId);
    }

    public void Update(Cart cart)
    {
        var index = _carts.FindIndex(c => c.Id == cart.Id);
        if (index == -1)
        {
            throw new Exception("Cart not found");
        }
        _carts[index] = cart;
    }

    public List<Cart> FindAll()
    {
        return _carts;
    }
    
    public List<Cart> FindCartsByUser(string userId)
{
    return _carts.Where(c => c.UserId == userId).ToList();
}

    public Cart? FindById(int id)
    {
        return _carts.FirstOrDefault(c => c.Id == id);
    }
}