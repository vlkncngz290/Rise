using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.DTOs.User;
using UserService.Repositories.User;
using UserService.Requests.User;
using UserService.Responses.BaseResponse;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        [HttpPost]
        public UserReadDto Post([FromBody] UserPostRequest userPostRequest)
        {
            return _userRepository.Create(userPostRequest);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_userRepository.Delete(id))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpGet]
        public BaseResponse<UserReadDto> GetAll([FromBody] UserGetAllRequest userGetAllRequest)
        {
            ICollection<UserReadDto> data = _userRepository.GetAllUsers(userGetAllRequest);
            return new BaseResponse<UserReadDto>(data.ToList(), userGetAllRequest.PageNumber, userGetAllRequest.PageSize, userGetAllRequest.TotalRecords);
        }

        [HttpGet("{id}")]
        public UserReadDto Get(Guid id, [FromBody] UserGetByIdRequest userGetByIdRequest)
        {
            return _userRepository.GetById(id, userGetByIdRequest);
        }


    }
}
