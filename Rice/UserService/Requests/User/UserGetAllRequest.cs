namespace UserService.Requests.User
{
    public class UserGetAllRequest:BaseRequest.BaseRequest
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Company { get; set; }
    }
}
