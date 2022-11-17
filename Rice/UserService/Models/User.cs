using UserService.Models.Base;

namespace UserService.Models
{
    public class User:BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
