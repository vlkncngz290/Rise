using System.ComponentModel.DataAnnotations;

namespace UserService.Requests.User
{
    public class UserPostRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Company { get; set; }
    }
}
