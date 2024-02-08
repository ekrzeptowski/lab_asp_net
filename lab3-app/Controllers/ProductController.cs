using lab3_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3_app.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new Product();
            product.Categories = _productService.FindAllCategoriesForViewModel();
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var product = _productService.FindById(id);
            if (product is not null)
            {
                product.Categories = _productService.FindAllCategoriesForViewModel();
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productService.FindById(id);
            if (product is not null)
            {
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete([FromForm] Product product)
        {
            if (_productService.FindById(product.Id) is not null)
            {
                _productService.Delete(product.Id);
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
            var product = _productService.FindById(id);
            if (product is not null)
            {
                return View(product);
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
                _productService.Add(product);

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
                if (_productService.FindById(product.Id) is not null)
                {
                    _productService.Update(product);
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