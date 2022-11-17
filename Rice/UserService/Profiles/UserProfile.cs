using AutoMapper;
using UserService.DTOs.User;
using UserService.Models;
using UserService.Requests.User;

namespace UserService.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserReadDto, User>();
            CreateMap<UserPostRequest, User>();
        }
    }
}
