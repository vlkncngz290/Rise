using UserService.DTOs.User;
using UserService.Requests.User;

namespace UserService.Repositories.User
{
    public interface IUserRepository
    {
        public UserReadDto Create(UserPostRequest userPostRequest);
        public Boolean Delete(Guid id);
        public ICollection<UserReadDto> GetAllUsers(UserGetAllRequest userGetAllRequest);
        public UserReadDto GetById(Guid id, UserGetByIdRequest userGetByIdRequest);
    }
}
