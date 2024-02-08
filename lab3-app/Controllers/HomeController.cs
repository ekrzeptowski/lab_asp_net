using lab3_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab3_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly ICartService _cartService;


        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, ICartService cartService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            ViewData["Visit"] = Response.HttpContext.Items[LastVisitCookie.CookieName];
            var categories = _categoryService.FindAll();
            var cartItems = _cartService.FindCartsByUser(User.Identity.Name);
            ViewData["Categories"] = categories;
            ViewData["CartItems"] = cartItems;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}