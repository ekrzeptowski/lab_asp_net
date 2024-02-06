using Data;
using Data.Entities;
using lab3_app.Mappers;
using Microsoft.EntityFrameworkCore;

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
            return ContactMapper.FromEntity(_context.Contacts
                .Include(c => c.Organization)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id));
        }

        public List<OrganizationEntity> FindAllOrganizationsForViewModel()
        {
            return _context.Organizations.ToList();
        }
        
        public PagingList<Contact> FindPage(int page, int size) 
        { 
            return PagingList<Contact>.Create(
                (p, s) => _context.Contacts
                    .OrderBy(b => b.Name)
                    .Skip((p-1) * size)
                    .Take(s)
                    .Select(e => ContactMapper.FromEntity(e))
                    .ToList(),
                _context.Contacts.Count(), 
                page, 
                size); 
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }
    }
}
