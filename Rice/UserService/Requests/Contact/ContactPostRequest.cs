using System.ComponentModel.DataAnnotations;

namespace UserService.Requests.Contact
{
    public class ContactPostRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Models.Contact.CONTACT_TYPES DataType { get; set; }
        [Required]
        public string DataValue { get; set; }
    }
}
