using System.Collections.Generic;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Artisan;

namespace WebApi.Services
{
    public interface IArtisanTypeService
    {
        IEnumerable<ArtisanTypeResponse> AddArtisanType(ArtisanTypeRequest model);
        void Delete(int id);
        IEnumerable<ArtisanTypeResponse> GetAll();
        ArtisanTypeResponse GetArtisanType(int id);
    }

    public class ArtisanTypeService : IArtisanTypeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ArtisanTypeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ArtisanTypeResponse> AddArtisanType(ArtisanTypeRequest model)
        {
            var artisan_type = _mapper.Map<ArtisanType>(model);
            _context.ArtisanTypes.Add(artisan_type);
            _context.SaveChanges();
            return _mapper.Map<IList<ArtisanTypeResponse>>(artisan_type);
        }

        public void Delete(int id)
        {
            var gal = getArtisanType(id);
            _context.ArtisanTypes.Remove(gal);
            _context.SaveChanges();
        }

        public IEnumerable<ArtisanTypeResponse> GetAll()
        {
            var gal = _context.ArtisanTypes;
            return _mapper.Map<IList<ArtisanTypeResponse>>(gal);
        }

        public ArtisanTypeResponse GetArtisanType(int id)
        {
            var artisan_type = getArtisanType(id);
            return _mapper.Map<ArtisanTypeResponse>(artisan_type);
        }

        private ArtisanType getArtisanType(int id)
        {
            var gal = _context.ArtisanTypes.Find(id);
            if (gal == null) throw new KeyNotFoundException("Artisan Type not found");
            return gal;
        }
    }
}