using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Gallery;

namespace WebApi.Services
{
    public interface IGalleryService
    {
        bool AddPhoto(GalleryRequests model);
        void Delete(int id);
        IEnumerable<GalleryResponse> GetAll(int id);
    }

    public class GalleryService : IGalleryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GalleryService(
            DataContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }
        public bool AddPhoto(GalleryRequests model)
        {
            try
            {
                var galpix = _mapper.Map<Gallery>(model);
                _context.Gallerys.Add(galpix);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(int id)
        {
            var gal = getGallery(id);
            _context.Gallerys.Remove(gal);
            _context.SaveChanges();
        }

        public IEnumerable<GalleryResponse> GetAll(int id)
        {
            var gal = _context.Gallerys.Where(x => x.AccountId == id);
            return _mapper.Map<IList<GalleryResponse>>(gal);
        }

        private Gallery getGallery(int id)
        {
            var gal = _context.Gallerys.Find(id);
            if (gal == null) throw new KeyNotFoundException("Service Type not found");
            return gal;
        }

    }
}