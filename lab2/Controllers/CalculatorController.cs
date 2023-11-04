using lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class CalculatorController : Controller
    {
        public enum Operators
        {
            ADD, SUB, MUL, DIV, POW
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }

            return View(model);
        }
    }
}
