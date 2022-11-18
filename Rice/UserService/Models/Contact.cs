using UserService.Models.Base;

namespace UserService.Models
{
    public class Contact:BaseModel
    {
        public enum CONTACT_TYPES
        {
            PHONE,
            MAIL,
            LOCATION

        }

        public Guid Id { get; set; }

        public CONTACT_TYPES DataType { get; set; }
        public string DataValue { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }

    }
}
