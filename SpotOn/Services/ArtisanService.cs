using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Artisan;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IArtisanService
    {
        bool AddArtisan(ArtisanRequest model);
        void Delete(int id);
        IEnumerable<ArtisanResponse> GetAll();
        IEnumerable<ArtisanDisplayResponse> GetArtisan(int id);
        ArtisanResponse GetArtisanByAccountId(int id);
        ArtisanResponse Update(int id);
        bool UpdatePhoto(int id, PhotoRequest model);
        Task<int> GetPages();
        Task<int> GetPages(int type_id);
        IEnumerable<ArtisanDisplayResponse> FindPaged(int page, int pageSize);
        IEnumerable<ArtisanDisplayResponse> FindPaged(int id, int page, int pageSize);
        IEnumerable<ArtisanDisplayResponse> FilterArtisan(ArtisanFilterRequest model);
        IEnumerable<ArtisanDisplayResponse> FilterArtisanByType(ArtisanFilterRequest model);
        bool UpdateReferrerCode(ReferrerCodeRequest model);
    }

    public class ArtisanService : IArtisanService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ArtisanService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddArtisan(ArtisanRequest model)
        {
            var artisan_exist = getArtisanByOwnerId(model.AccountId);
            if (artisan_exist == null)
            {
                var artisan = _mapper.Map<Artisan>(model);
                artisan.DateApproved = DateTime.UtcNow.AddDays(-1);
                artisan.Ratings = 0;
                artisan.IsApproved = false;
                artisan.RefererCount = 0;
                artisan.RefererCode = "RC" + RandomGenerator.GenerateRandomString(6);
                _context.Artisans.Add(artisan);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public ArtisanResponse Update(int id)//, UpdatePaymentRequest model)
        {
            var artisan = getArtisanByOwnerId(id);
            if (artisan == null)
            {
                throw new AppException("The Artisan does not exist!");

            }
            else
            {
                //_mapper.Map(model, artisan);
                artisan.DateApproved = DateTime.UtcNow;
                artisan.IsApproved = true;
                _context.Artisans.Update(artisan);
                _context.SaveChanges();
                return _mapper.Map<ArtisanResponse>(artisan);
            }
        }

        public void Delete(int id)
        {
            var gal = getArtisan(id);
            _context.Artisans.Remove(gal);
            _context.SaveChanges();
        }

        public IEnumerable<ArtisanResponse> GetAll()
        {
            var gal = _context.Artisans.Where(x => x.IsApproved == true && x.DateApproved.Value.AddYears(1) > DateTime.Now);
            return _mapper.Map<IList<ArtisanResponse>>(gal);
        }

        public IEnumerable<ArtisanDisplayResponse> GetArtisan(int id)
        {
            var artisan = _context.Artisans
                .Join(_context.ArtisanTypes,
                 e => e.ArtisanTypeId,
                 d => d.Id,
                 (artisan, artisantype) => new
                 {
                     artisan.Id,
                     artisan.AccountId,
                     artisan.Name,
                     artisan.Location,
                     artisan.Photo,
                     artisan.Phone,
                     artisan.LocalAreaId,
                     artisan.RefererCode,
                     artisan.RefererCount,
                     artisantype.Category
                 })
                .Where(x => x.Id == id)
                .ToList();

            List<ArtisanDisplayResponse> responseList = new List<ArtisanDisplayResponse>();

            foreach (var response in artisan)
            {
                ArtisanDisplayResponse responseDisplayResponse = new ArtisanDisplayResponse
                {
                    Id = response.Id,
                    Name = response.Name,
                    Location = GetState(response.LocalAreaId) + ", " + response.Location,
                    Photo = response.Photo,
                    Phone = response.Phone,
                    Category = response.Category,
                    RefererCode = response.RefererCode,
                    RefererCount = response.RefererCount
                };
                responseList.Add(responseDisplayResponse);
            }

            return _mapper.Map<IList<ArtisanDisplayResponse>>(responseList);
        }

        public ArtisanResponse GetArtisanByAccountId(int id)
        {
            var artisan = getArtisanByOwnerId(id);
            return _mapper.Map<ArtisanResponse>(artisan);
        }



        private Artisan getArtisan(int id)
        {
            var gal = _context.Artisans.Find(id);
            if (gal == null) return null;
            return gal;
        }

        public bool UpdatePhoto(int id, PhotoRequest model)
        {
            var gal = getArtisanByOwnerId(id);

            if (gal == null)
                return false;

            gal.Photo = model.Photo;
            _context.Artisans.Update(gal);
            _context.SaveChanges();
            return true;
        }

        public Task<int> GetPages()
        {
            var lists = _context.Artisans
                .Where(x => x.IsApproved == true && x.DateApproved.Value.AddYears(1) > DateTime.Now)
                .ToList();
            double pageCount = (double)((decimal)lists.Count / Convert.ToDecimal(50));
            var pages = (int)Math.Ceiling(pageCount);

            return Task.FromResult(pages);
        }


        public Task<int> GetPages(int type_id)
        {
            var lists = _context.Artisans
                .Where(x => x.IsApproved == true && x.ArtisanTypeId == type_id && x.DateApproved.Value.AddYears(1) > DateTime.Now)
                .ToList();

            double pageCount = (double)((decimal)lists.Count / Convert.ToDecimal(50));
            var pages = (int)Math.Ceiling(pageCount);

            return Task.FromResult(pages);
        }

        public IEnumerable<ArtisanDisplayResponse> FindPaged(int page, int pageSize)
        {
            var artisan = _context.Artisans
                .Join(_context.ArtisanTypes,
                 e => e.ArtisanTypeId,
                 d => d.Id,
                 (artisan, artisantype) => new
                 {
                     artisan.Id,
                     artisan.DateApproved,
                     artisan.Name,
                     artisan.Location,
                     artisan.Photo,
                     artisan.IsApproved,
                     artisan.LocalAreaId,
                     artisantype.Category
                 })
                .Where(x => x.IsApproved == true && x.DateApproved.Value.AddYears(1) > DateTime.Now)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();

            List<ArtisanDisplayResponse> responseList = new List<ArtisanDisplayResponse>();

            foreach (var response in artisan)
            {
                ArtisanDisplayResponse responseDisplayResponse = new ArtisanDisplayResponse
                {
                    Id = response.Id,
                    Name = response.Name,
                    Location = GetState(response.LocalAreaId) + ", " + response.Location,
                    Photo = response.Photo,
                    Category = response.Category
                };
                responseList.Add(responseDisplayResponse);
            }

            return _mapper.Map<IList<ArtisanDisplayResponse>>(responseList);
        }

        public IEnumerable<ArtisanDisplayResponse> FindPaged(int id, int page, int pageSize)
        {
            var artisan = _context.Artisans
                .Join(_context.ArtisanTypes,
                 e => e.ArtisanTypeId,
                 d => d.Id,
                 (artisan, artisantype) => new
                 {
                     artisan.Id,
                     artisan.DateApproved,
                     artisan.ArtisanTypeId,
                     artisan.Name,
                     artisan.Location,
                     artisan.Photo,
                     artisan.IsApproved,
                     artisan.LocalAreaId,
                     artisantype.Category
                 })
                .Where(x => x.IsApproved == true && x.ArtisanTypeId == id && x.DateApproved.Value.AddYears(1) > DateTime.Now)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();

            List<ArtisanDisplayResponse> responseList = new List<ArtisanDisplayResponse>();

            foreach (var response in artisan)
            {
                ArtisanDisplayResponse responseDisplayResponse = new ArtisanDisplayResponse
                {
                    Id = response.Id,
                    Name = response.Name,
                    Location = GetState(response.LocalAreaId) + ", " + response.Location,
                    Photo = response.Photo,
                    Category = response.Category
                };
                responseList.Add(responseDisplayResponse);
            }

            return _mapper.Map<IList<ArtisanDisplayResponse>>(responseList);
        }

        public IEnumerable<ArtisanDisplayResponse> FilterArtisan(ArtisanFilterRequest model)
        {
            var artisan = _context.Artisans
                .Join(_context.ArtisanTypes,
                 e => e.ArtisanTypeId,
                 d => d.Id,
                 (artisan, artisantype) => new
                 {
                     artisan.Id,
                     artisan.DateApproved,
                     artisan.ArtisanTypeId,
                     artisan.Name,
                     artisan.Location,
                     artisan.Photo,
                     artisan.IsApproved,
                     artisan.LocalAreaId,
                     artisantype.Category
                 })
                .Where(x => x.IsApproved == true && x.DateApproved.Value.AddYears(1) < DateTime.Now && x.LocalAreaId == model.LocalAreaId && x.Location == model.Location)
                .ToList();

            List<ArtisanDisplayResponse> responseList = new List<ArtisanDisplayResponse>();

            foreach (var response in artisan)
            {
                ArtisanDisplayResponse responseDisplayResponse = new ArtisanDisplayResponse
                {
                    Id = response.Id,
                    Name = response.Name,
                    Location = GetState(response.LocalAreaId) + ", " + response.Location,
                    Photo = response.Photo,
                    Category = response.Category
                };
                responseList.Add(responseDisplayResponse);
            }

            return _mapper.Map<IList<ArtisanDisplayResponse>>(responseList);
        }


        public IEnumerable<ArtisanDisplayResponse> FilterArtisanByType(ArtisanFilterRequest model)
        {
            var artisan = _context.Artisans
                .Join(_context.ArtisanTypes,
                 e => e.ArtisanTypeId,
                 d => d.Id,
                 (artisan, artisantype) => new
                 {
                     artisan.Id,
                     artisan.DateApproved,
                     artisan.ArtisanTypeId,
                     artisan.Name,
                     artisan.Location,
                     artisan.Photo,
                     artisan.IsApproved,
                     artisan.LocalAreaId,
                     artisantype.Category
                 })
                .Where(x => x.IsApproved == true && x.DateApproved.Value.AddYears(1) < DateTime.Now && x.ArtisanTypeId == model.ArtisanTypeId && x.LocalAreaId == model.LocalAreaId && x.Location == model.Location)
                .ToList();

            List<ArtisanDisplayResponse> responseList = new List<ArtisanDisplayResponse>();

            foreach (var response in artisan)
            {
                ArtisanDisplayResponse responseDisplayResponse = new ArtisanDisplayResponse
                {
                    Id = response.Id,
                    Name = response.Name,
                    Location = GetState(response.LocalAreaId) + ", " + response.Location,
                    Photo = response.Photo,
                    Category = response.Category
                };
                responseList.Add(responseDisplayResponse);
            }

            return _mapper.Map<IList<ArtisanDisplayResponse>>(responseList);
        }

        private string GetState(int LocalAreaId)
        {
            var state_id = _context.LocalAreas.Find(LocalAreaId).UserStateId;
            return _context.UserStates.Find(state_id).StateName.ToUpperInvariant();
        }


        private Artisan getArtisanByOwnerId(int id)
        {
            try
            {
                var gal = _context.Artisans.FirstOrDefault(c => c.AccountId == id);
                if (gal == null) return null;
                return gal;
            }
            catch { return null; }
        }

        public bool UpdateReferrerCode(ReferrerCodeRequest model)
        {
            var code = _context.Artisans.FirstOrDefault(c => c.RefererCode == model.ReferrerCode);
            if (code == null) return false;
            code.RefererCount = code.RefererCount + 1;
            _context.SaveChanges();
            return true;
        }
    }
}