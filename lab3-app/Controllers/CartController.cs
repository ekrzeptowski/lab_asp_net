using lab3_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab3_app.Controllers;

[Authorize(Roles = "admin, user")]
public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly IProductService _productService;

    public CartController(ICartService cartService, IProductService productService)
    {
        _cartService = cartService;
        _productService = productService;
    }

    [HttpPost]
    public IActionResult AddToCart([FromForm] int productId, [FromForm] int quantity)
    {
        var product = _productService.FindById(productId);
        if (User.Identity != null && product is not null && quantity > 0 && User.Identity.IsAuthenticated)
        {
            if (User.Identity.Name != null) _cartService.Add(product, quantity, User.Identity.Name);
            return RedirectToAction("browse", "cart", new { id = product.CategoryId });
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult RemoveFromCart([FromForm] int id)
    {
        if (id > 0)
        {
            _cartService.Delete(id);
            return RedirectToAction("Checkout");
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        return View(_cartService.FindCartsByUser(User.Identity.Name));
    }

    [HttpPost]
    public IActionResult Checkout([FromForm] List<Cart> carts)
    {
        var cartItems = _cartService.FindCartsByUser(User.Identity.Name);
        _cartService.ClearCartByUser(User.Identity.Name);
        return View("Summary", cartItems);
    }

    [HttpGet]
    public IActionResult Browse([FromRoute] int id, [FromQuery] int page = 1, [FromQuery] int limit = 10)
    {
        var products = _productService.FindPage(id, page, limit);
        return View(products);
    }

    [HttpGet]
    public IActionResult Product([FromRoute] int id)
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
}