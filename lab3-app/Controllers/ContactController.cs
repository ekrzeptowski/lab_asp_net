using lab3_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab3_app.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService) => _contactService = contactService;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var contact = _contactService.FindById(id);
            if (contact is not null)
            {
                return View(contact);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = _contactService.FindById(id);
            if (contact is not null)
            {
                return View(contact);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete([FromForm] Contact contact)
        {
            if (_contactService.FindById(contact.Id) is not null)
            {
                _contactService.Delete(contact.Id);
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
            var contact = _contactService.FindById(id);
            if (contact is not null)
            {
                return View(contact);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromForm] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(contact);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (_contactService.FindById(contact.Id) is not null)
                {
                    _contactService.Update(contact);
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
