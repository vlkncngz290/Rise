using UserService.DTOs.Contact;
using UserService.Models;

namespace UserService.DTOs.User
{
    public class UserReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ICollection<ContactSimpleDto> Contacts { get; set; }
    }
}
