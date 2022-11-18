using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.DTOs.User;
using UserService.Requests.User;

namespace UserService.Repositories.User
{
    public class UserRepository:IUserRepository
    {
        private readonly PostgresqlDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(PostgresqlDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public UserReadDto Create(UserPostRequest userPostRequest)
        {
            if (userPostRequest==null)
            {
                throw new ArgumentNullException(nameof(userPostRequest));
            }

            Models.User user = _mapper.Map<Models.User>(userPostRequest);
            _context.Users.Add(user);
            SaveChanges();
            return _mapper.Map<UserReadDto>(user);

        }

        public bool Delete(Guid id)
        {
            Models.User user=_context.Users.FirstOrDefault(x => x.Id==id);
            if (user==null)
            {
                throw new KeyNotFoundException(nameof(id));
            }
            _context.Users.Remove(user);
            SaveChanges();
            return true;
        }

        public ICollection<UserReadDto> GetAllUsers(UserGetAllRequest userGetAllRequest)
        {
            var users = _context.Users.AsQueryable();
            if (userGetAllRequest.Name!=null)
            {
                users=users.Where(x=>x.Name.Contains(userGetAllRequest.Name));
            }

            if (userGetAllRequest.Surname!=null)
            {
                users = users.Where(u => u.Surname.Contains(userGetAllRequest.Surname));
            }

            if (userGetAllRequest.Company!=null)
            {
                users=users.Where(u => u.Company.Contains(userGetAllRequest.Company));
            }

            foreach (string relation in userGetAllRequest.Include)
            {
                users = users.Include(relation);
            }
            userGetAllRequest.TotalRecords=users.Count();
            var result = users.OrderBy(u => u.Id)
                .Skip(userGetAllRequest.GetOffset())
                .Take(userGetAllRequest.GetLimit())
                .ToList();
            return _mapper.Map<ICollection<UserReadDto>>(result);
        }

        public UserReadDto GetById(Guid id, UserGetByIdRequest userGetByIdRequest)
        {
            var user = _context.Users.Where(u => u.Id == id).AsQueryable();
            foreach (string relation in userGetByIdRequest.Include)
            {
                user=user.Include(relation);
            }

            var result = user.FirstOrDefault();
            return _mapper.Map<UserReadDto>(result);
        }

        private Boolean SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
