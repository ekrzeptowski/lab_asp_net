using lab3_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3_app.Controllers
{
    public class ContactController : Controller
    {
        static Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>()
        {
            {1, new Contact(){ Id=1, Name="Stefan", Email="a@asas.com", Phone="123456789", Birth=new DateTime(1980,1,3)} },
            {2, new Contact(){ Id=2, Name="Jan", Email="j@asas.com", Phone="1122334455", Birth=new DateTime(1990,3,12)}},
            {3, new Contact(){ Id=3, Name="Anna", Email="a@asas.com", Phone="678543445", Birth=new DateTime(1985,4,21)}}
        };
        public IActionResult Index()
        {
            return View(_contacts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            if (_contacts.ContainsKey(id))
            {
                return View(_contacts[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_contacts.ContainsKey(id))
            {
                return View(_contacts[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete([FromForm] Contact contact)
        {
            if (_contacts.ContainsKey(contact.Id))
            {
                _contacts.Remove(contact.Id);
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
            if (_contacts.ContainsKey(id))
            {
                return View(_contacts[id]);
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
                int id = _contacts.Keys.Count != 0 ? _contacts.Keys.Max() : 0;
                contact.Id = id + 1;
                _contacts.Add(contact.Id, contact);

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
                if (_contacts.ContainsKey(contact.Id))
                {
                    _contacts[contact.Id] = contact;
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
