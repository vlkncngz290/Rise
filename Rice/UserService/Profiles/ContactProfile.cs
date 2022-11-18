using AutoMapper;
using UserService.DTOs.Contact;
using UserService.Models;
using UserService.Requests.Contact;

namespace UserService.Profiles
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactPostRequest, Contact>();
            CreateMap<ContactReadDto, Contact>();
            CreateMap<Contact, ContactReadDto>();
            CreateMap<Contact, ContactSimpleDto>();
            CreateMap<ContactSimpleDto, Contact>();
        }
    }
}
