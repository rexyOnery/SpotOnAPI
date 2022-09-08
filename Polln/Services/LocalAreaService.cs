using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.LocalArea;

namespace WebApi.Services
{
    public interface ILocalAreaService
    {
        void AddLocalArea(LocalAreaRequest model);
        void Delete(int id);
        IEnumerable<LocalAreaResponse> GetAll();
        LocalAreaResponse GetLocalArea(int id);
        IEnumerable<LocalAreaResponse> GetLocalAreaByState(int id);
    }

    public class LocalAreaService : ILocalAreaService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LocalAreaService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddLocalArea(LocalAreaRequest model)
        {
            var _find_location = _context.LocalAreas.Where(x => x.LocationName == model.LocationName);
            if (_find_location.Count() == 0)
            {
                var localarea = _mapper.Map<LocalArea>(model);
                _context.LocalAreas.Add(localarea);
                _context.SaveChanges();
            }
            return;
        }

        public void Delete(int id)
        {
            var delete = getLocalAreaById(id);
            _context.LocalAreas.Remove(delete);
            _context.SaveChanges();
        }

        public IEnumerable<LocalAreaResponse> GetAll()
        {
            var gal = _context.LocalAreas;
            return _mapper.Map<IList<LocalAreaResponse>>(gal);
        }

        public LocalAreaResponse GetLocalArea(int id)
        {
            var artisan_type = getLocalAreaById(id);
            return _mapper.Map<LocalAreaResponse>(artisan_type);
        }

        public IEnumerable<LocalAreaResponse> GetLocalAreaByState(int id)
        {
            var gal = _context.LocalAreas.Where(a => a.UserStateId == id);
            return _mapper.Map<IList<LocalAreaResponse>>(gal);
        }

        private LocalArea getLocalAreaById(int id)
        {
            var gal = _context.LocalAreas.Find(id);
            if (gal == null) throw new KeyNotFoundException("Artisan Type not found");
            return gal;
        }
    }
}