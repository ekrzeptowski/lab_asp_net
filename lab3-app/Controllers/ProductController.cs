using lab3_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3_app.Controllers
{
    public class ProductController : Controller
    {
        static Dictionary<int, Product> _products = new Dictionary<int, Product>()
        {
            {1, new Product(){ Id=1, Name="Produkt1 abc", Producent="Producent abc", Price=4.1M, ProductionDate=new DateTime(2020, 10, 10)} },
            {2, new Product(){ Id=2, Name="Produkt2 def", Producent="Producent def", Price=0.99M, ProductionDate=new DateTime(2018, 1, 15), Description="Opis produktu 2"}},
            {3, new Product(){ Id=3, Name="Produkt3 ghi", Producent="Producent ghi", Price=389.99M, ProductionDate=new DateTime(2021, 6, 7)}}    
        };
        public IActionResult Index()
        {
            return View(_products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            if (_products.ContainsKey(id))
            {
                return View(_products[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_products.ContainsKey(id))
            {
                return View(_products[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete([FromForm] Product product)
        {
            if (_products.ContainsKey(product.Id))
            {
                _products.Remove(product.Id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_products.ContainsKey(id))
            {
                return View(_products[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                int id = _products.Keys.Count != 0 ? _products.Keys.Max() : 0;
                product.Id = id + 1;
                _products.Add(product.Id, product);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                if (_products.ContainsKey(product.Id))
                {
                    _products[product.Id] = product;
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
