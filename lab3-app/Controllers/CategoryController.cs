using lab3_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3_app.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    public IActionResult Index()
    {
        return View(_categoryService.FindAll());
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create([FromForm] Category category)
    {
        if (ModelState.IsValid)
        {
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }
        return View(category);
    }
    
    [HttpGet]
    public IActionResult Edit([FromRoute] int id)
    {
        var category = _categoryService.FindById(id);
        if (category is not null)
        {
            return View(category);
        }
        else
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    public IActionResult Edit([FromForm] Category category)
    {
        if (ModelState.IsValid)
        {
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }
        return View(category);
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var category = _categoryService.FindById(id);
        if (category is not null)
        {
            return View(category);
        }
        else
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    public IActionResult Delete([FromForm] Category category)
    {
        if (_categoryService.FindById(category.Id) is not null)
        {
            _categoryService.Delete(category.Id);
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
    
}