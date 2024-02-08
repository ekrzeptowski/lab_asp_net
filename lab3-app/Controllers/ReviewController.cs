using lab3_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab3_app.Controllers;

[Authorize(Roles = "admin")]
public class ReviewController : Controller
{
    private readonly IReviewService _reviewService;
    public ReviewController(IReviewService reviewService) => _reviewService = reviewService;

    [HttpGet]
    public IActionResult Edit([FromRoute] int id)
    {
        var review = _reviewService.FindById(id);
        if (review is not null)
        {
            return View(review);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Edit([FromForm] Review review)
    {
        if (_reviewService.FindById(review.Id) is not null)
        {
            _reviewService.Update(review);
            return RedirectToAction("Details", "Product", new { id = review.ProductId });
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var review = _reviewService.FindById(id);
        if (review is not null)
        {
            return View(review);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Delete([FromForm] Review review)
    {
        if (_reviewService.FindById(review.Id) is not null)
        {
            _reviewService.Delete(review.Id);
            return RedirectToAction("Details", "Product", new { id = review.ProductId });
        }
        else
        {
            return NotFound();
        }
    }
}