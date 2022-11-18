using UserService.DTOs.Contact;
using UserService.Requests.Contact;

namespace UserService.Repositories.Contact
{
    public interface IContactRepository
    {
        public ContactReadDto Create(ContactPostRequest contactPostRequest);
        public Boolean Delete(Guid id);
    }
}
