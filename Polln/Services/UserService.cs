using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using BC = BCrypt.Net.BCrypt;

namespace WebApi.Services
{
    public interface IUserService
    {
        bool AddUser(UserRequest model);
        void Delete(int id);
        IEnumerable<UserResponse> GetAll();
        UserResponse GetUserByAccountId(string phone);
        UserResponse GetUserById(int id);
    }

    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddUser(UserRequest model)
        {
            var user_exist = getUserByAccountId(model.Phone);
            if (user_exist == null)
            {
                var user = _mapper.Map<User>(model);
                user.Password = BC.HashPassword(model.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(int id)
        {
            var user = getUserById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<UserResponse> GetAll()
        {
            var user = _context.Users;
            return _mapper.Map<IList<UserResponse>>(user);
        }

        public UserResponse GetUserByAccountId(string phone)
        {
            var user = getUserByAccountId(phone);
            return _mapper.Map<UserResponse>(user);
        }

        public UserResponse GetUserById(int id)
        {
            var user = getUserById(id);
            return _mapper.Map<UserResponse>(user);
        }

        private User getUserByAccountId(string phone)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(c => c.Phone == phone);
                if (user == null) return null;
                return user;
            }
            catch { return null; }
        }

        private User getUserById(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user == null) return null;
                return user;
            }
            catch { return null; }
        }
    }

}