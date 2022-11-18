using AutoMapper;
using UserService.Context;
using UserService.DTOs.Contact;
using UserService.Requests.Contact;

namespace UserService.Repositories.Contact
{
    public class ContactRepository:IContactRepository
    {
        private readonly PostgresqlDbContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(PostgresqlDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public ContactReadDto Create(ContactPostRequest contactPostRequest)
        {
            if (contactPostRequest==null)
            {
                throw new ArgumentNullException(nameof(contactPostRequest));
            }

            Models.Contact contact = _mapper.Map<Models.Contact>(contactPostRequest);
            _context.Contacts.Add(contact);
            SaveChanges();
            return _mapper.Map<ContactReadDto>(contact);

        }

        public bool Delete(Guid id)
        {
            Models.Contact contact=_context.Contacts.FirstOrDefault(x => x.Id==id);
            if (contact==null)
            {
                throw new KeyNotFoundException(nameof(id));
            }
            _context.Contacts.Remove(contact);
            SaveChanges();
            return true;
        }

        private Boolean SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
