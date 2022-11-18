namespace UserService.DTOs.Contact
{
    public class ContactReadDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Models.Contact.CONTACT_TYPES DataType { get; set; }
        public string DataValue { get; set; }
    }
}
