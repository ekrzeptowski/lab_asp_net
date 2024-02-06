using Data;
using Microsoft.AspNetCore.Mvc;

namespace lab3_app.Controllers;

[Route("api/organizations")]
[ApiController]
public class OrganizationApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrganizationApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetFiltered(string filter)
    {
        return Ok(_context.Organizations
            .Where(o => o.Title.StartsWith(filter))
            .Select(o => new { o.Title, o.Id })
            .ToList());
    }
}