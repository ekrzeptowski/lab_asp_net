namespace lab3_app.Models;

public interface ICartService
{
    int Add(Product product, int quantity, string userId);
    void Delete(int id);
    void Update(Cart cart);
    List<Cart> FindAll();
    Cart? FindById(int id);
    List<Cart> FindCartsByUser(string userId);
    void ClearCartByUser(string userId);
    
}