using Data.Entities;
using lab3_app.Models;

namespace lab3_app.Mappers
{
    public class ContactMapper
    {
        public static Contact FromEntity(ContactEntity entity)
        {
            return new Contact
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Priority = (Priority)entity.Priority,
                Birth = entity.Birth
            };
        }

        public static ContactEntity ToEntity(Contact contact)
        {
            return new ContactEntity
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
                Priority = (int)contact.Priority,
                Birth = contact.Birth
            };
        }
    }
}
