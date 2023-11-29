using Data;
using Data.Entities;
using lab3_app.Mappers;

namespace lab3_app.Models
{
    public class EFContactService : IContactService
    {
        private AppDbContext _context;
        public EFContactService(AppDbContext context) => _context = context;

        public int Add(Contact contact)
        {
            var e = _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            ContactEntity? find = _context.Contacts.Find(id);
            if (find != null)
            {
                _context.Contacts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }

        public Contact? FindById(int id)
        {
            return ContactMapper.FromEntity(_context.Contacts.Find(id));
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }
    }
}
