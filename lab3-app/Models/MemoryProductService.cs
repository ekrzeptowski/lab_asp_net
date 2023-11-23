
namespace lab3_app.Models
{
    public class MemoryProductService : IProductService
    {
        private Dictionary<int, Product> _products = new Dictionary<int, Product>()
        {
            {1, new Product(){ Id=1, Name="Produkt1 abc", Producent="Producent abc", Price=4.1M, ProductionDate=new DateTime(2020, 10, 10)} },
            {2, new Product(){ Id=2, Name="Produkt2 def", Producent="Producent def", Price=0.99M, ProductionDate=new DateTime(2018, 1, 15), Description="Opis produktu 2"}},
            {3, new Product(){ Id=3, Name="Produkt3 ghi", Producent="Producent ghi", Price=389.99M, ProductionDate=new DateTime(2021, 6, 7)}}
        };

        public int Add(Product product)
        {
            int id = _products.Keys.Count != 0 ? _products.Keys.Max() : 0;
            product.Id = id + 1;
            _products.Add(product.Id, product);
            return product.Id;
        }

        public void Delete(int id)
        {
            _products.Remove(id);
        }

        public List<Product> FindAll()
        {
            return _products.Values.ToList();
        }

        public Product? FindById(int id)
        {
            return _products[id];
        }

        public void Update(Product product)
        {
            _products[product.Id] = product;
        }
    }
}
