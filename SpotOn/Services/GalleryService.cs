using System;
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
        IEnumerable<GalleryResponse> GetAllArtisanPhoto(int id);
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
            var gallery_count = getAllGallery(model.AccountId);
            if (gallery_count.Count() <= 4)
            {
                var galpix = _mapper.Map<Gallery>(model);
                galpix.DateAdded = DateTime.UtcNow.ToShortDateString();
                _context.Gallerys.Add(galpix);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            var gal = getGallery(id);
            _context.Gallerys.Remove(gal);
            _context.SaveChanges();
        }

        public IEnumerable<GalleryResponse> GetAll(int id)
        {
            var artisan_id = _context.Artisans.Find(id);
            var gal = _context.Gallerys.Where(x => x.AccountId == artisan_id.AccountId);
            return _mapper.Map<IList<GalleryResponse>>(gal);
        }

        public IEnumerable<GalleryResponse> GetAllArtisanPhoto(int id)
        {
            var gal = _context.Gallerys.Where(x => x.AccountId == id);
            return _mapper.Map<IList<GalleryResponse>>(gal);
        }

        private Gallery getGallery(int id)
        {
            var gal = _context.Gallerys.Find(id);
            if (gal == null) return null;
            return gal;
        }

        private IEnumerable<Gallery> getAllGallery(int id)
        {
            var gal = _context.Gallerys.Where(x => x.AccountId == id);
            if (gal == null) return null;
            return gal;
        }

        // function calculateDaysBetweenDates(begin, end) {
        //     var oneDay = 24*60*60*1000; // hours*minutes*seconds*milliseconds
        //     var firstDate = new Date(begin);
        //     var secondDate = new Date(end);
        //     var diffDays = Math.round(Math.abs((firstDate.getTime() - secondDate.getTime())/(oneDay)));
        //     return diffDays;
        // }

    }
}