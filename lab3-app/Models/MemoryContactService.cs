
namespace lab3_app.Models
{
    public class MemoryContactService : IContactService
    {
        private Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>()
        {
            {1, new Contact(){ Id=1, Name="Stefan", Email="a@asas.com", Phone="123456789", Birth=new DateTime(1980,1,3)} },
            {2, new Contact(){ Id=2, Name="Jan", Email="j@asas.com", Phone="1122334455", Birth=new DateTime(1990,3,12)}},
            {3, new Contact(){ Id=3, Name="Anna", Email="a@asas.com", Phone="678543445", Birth=new DateTime(1985,4,21)}}
        };

        private IDateTimeProvider _timeProvider;

        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public int Add(Contact contact)
        {
            int id = _contacts.Keys.Count != 0 ? _contacts.Keys.Max() : 0;
            contact.Id = id + 1;
            contact.Created = _timeProvider.GetCurrentTime;
            _contacts.Add(contact.Id, contact);
            return contact.Id;
        }

        public void Delete(int id)
        {
            _contacts.Remove(id);
        }

        public List<Contact> FindAll()
        {
            return _contacts.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _contacts[id];
        }

        public void Update(Contact contact)
        {
            _contacts[contact.Id] = contact;
        }
    }
}
