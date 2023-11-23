namespace lab3_app.Models
{
    public interface IProductService
    {
        int Add(Product product);
        void Delete(int id);
        void Update(Product product);
        List<Product> FindAll();
        Product? FindById(int id);
    }
}
