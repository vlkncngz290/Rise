namespace UserService.DTOs.Contact
{
    public class ContactSimpleDto
    {
        public Guid Id { get; set; }
        public Models.Contact.CONTACT_TYPES DataType { get; set; }
        public string DataValue { get; set; }
    }
}
