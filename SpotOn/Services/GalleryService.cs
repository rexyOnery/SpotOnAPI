using System.Collections.Generic;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Gallery;

namespace WebApi.Services
{
    public interface IGalleryService
    {
        IEnumerable<GalleryResponse> AddPhoto(GalleryRequests model);
        void Delete(int id);
        IEnumerable<GalleryResponse> GetAll();
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
        public IEnumerable<GalleryResponse> AddPhoto(GalleryRequests model)
        {
            var galpix = _mapper.Map<Gallery>(model);
            _context.Gallerys.Add(galpix);
            _context.SaveChanges();
            return _mapper.Map<IList<GalleryResponse>>(galpix);
        }

        public void Delete(int id)
        {
            var gal = getGallery(id);
            _context.Gallerys.Remove(gal);
            _context.SaveChanges();
        }

        public IEnumerable<GalleryResponse> GetAll()
        {
            var gal = _context.Gallerys;
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