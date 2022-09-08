using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.PresidentialCandidate;

namespace WebApi.Services
{
    public interface IPresidentialCandidateService
    {
        bool AddPresidentialCandidate(PresidentialCandidateRequest model);
        bool AddPresidentialCandidatePhoto(PresidentialCandidatePhotoRequest model);
        bool AddPresidentialCandidatePartyLogo(PresidentialCandidatePartyLogoRequest model);
        IEnumerable<PresidentialCandidateResponse> GetAll();
        PresidentialCandidateResponse GetPresidentialCandidateById(int id);
        void Delete(int id);
    }

    public class PresidentialCandidateService : IPresidentialCandidateService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PresidentialCandidateService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddPresidentialCandidate(PresidentialCandidateRequest model)
        {
            var user_exist = getPresidentByParty(model.Party);
            if (user_exist == null)
            {
                var _presidentialCandidate = _mapper.Map<PresidentialCandidate>(model);
                _context.PresidentialCandidates.Add(_presidentialCandidate);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddPresidentialCandidatePartyLogo(PresidentialCandidatePartyLogoRequest model)
        {
            var user_exist = getPresidentById(model.Id);
            if (user_exist != null)
            {
                user_exist.PartyLogo = model.PartyLogo;
                _context.PresidentialCandidates.Update(user_exist);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddPresidentialCandidatePhoto(PresidentialCandidatePhotoRequest model)
        {
            var user_exist = getPresidentById(model.Id);
            if (user_exist != null)
            {
                user_exist.Photo = model.Photo;
                _context.PresidentialCandidates.Update(user_exist);
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
            var _presidentialCandidate = getPresidentById(id);
            if (_presidentialCandidate != null)
            {
                _context.PresidentialCandidates.Remove(_presidentialCandidate);
                _context.SaveChanges();
            }
        }

        public IEnumerable<PresidentialCandidateResponse> GetAll()
        {
            var presidentialCandidates = _context.PresidentialCandidates;
            return _mapper.Map<IList<PresidentialCandidateResponse>>(presidentialCandidates);
        }

        public PresidentialCandidateResponse GetPresidentialCandidateById(int id)
        {
            var presidentialCandidate = getPresidentById(id);
            return _mapper.Map<PresidentialCandidateResponse>(presidentialCandidate);
        }

        private PresidentialCandidate getPresidentById(int id)
        {
            var _PresidentialCandidate = _context.PresidentialCandidates.Find(id);
            return _PresidentialCandidate;
        }

        private PresidentialCandidate getPresidentByParty(string party)
        {
            try
            {
                var user = _context.PresidentialCandidates.FirstOrDefault(x => x.Party == party);
                if (user == null) return null;
                return user;
            }
            catch { return null; }
        }

    }
}