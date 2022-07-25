using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.UserState;

namespace WebApi.Services
{
    public interface IUserStateService
    {
        void AddUserState(UserStateRequest model);
        void Delete(int id);
        IEnumerable<UserStateResponse> GetAll();
        UserStateResponse GetUserState(int id);
    }

    public class UserStateService : IUserStateService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserStateService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddUserState(UserStateRequest model)
        {
            var _find_state = _context.UserStates.Where(x => x.StateName == model.StateName);
            if (_find_state.Count() == 0)
            {
                var user_state = _mapper.Map<UserState>(model);
                _context.UserStates.Add(user_state);
                _context.SaveChanges();
            }
            return;
        }

        public void Delete(int id)
        {
            var delete = getUserStateById(id);
            _context.UserStates.Remove(delete);
            _context.SaveChanges();
        }

        public IEnumerable<UserStateResponse> GetAll()
        {
            var gus = _context.UserStates.OrderBy(u => u.StateName);
            return _mapper.Map<IList<UserStateResponse>>(gus);
        }

        public UserStateResponse GetUserState(int id)
        {
            var artisan_type = getUserStateById(id);
            return _mapper.Map<UserStateResponse>(artisan_type);
        }

        private UserState getUserStateById(int id)
        {
            var gal = _context.UserStates.Find(id);
            if (gal == null) throw new KeyNotFoundException("Artisan Type not found");
            return gal;
        }
    }
}