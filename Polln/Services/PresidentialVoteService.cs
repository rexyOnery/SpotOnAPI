using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.PresidentialVote;

namespace WebApi.Services
{
    public interface IPresidentialVoteService
    {
        bool AddPresidentialVote(PresidentialVoteRequest model);
        IEnumerable<PresidentialVoteResponse> GetAll();
        PresidentialVoteResponse GetPresidentialVoteById(int id);
        void Delete(int id);
    }

    public class PresidentialVoteService : IPresidentialVoteService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PresidentialVoteService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddPresidentialVote(PresidentialVoteRequest model)
        {
            var user_not_voted = getCheckUserAlreadyVoted(model.UserId);
            if (user_not_voted == true)
            {
                var _presidentialVotes = getPresidentialVoteByCandidateId(model.PresidentialCandidateId);
                if (_presidentialVotes == null)
                {
                    var _presidentialVote = _mapper.Map<PresidentialVote>(model);
                    _presidentialVote.VoteCount = 1;
                    _context.PresidentialVotes.Add(_presidentialVote);
                    _context.SaveChanges();
                }
                else
                {
                    _presidentialVotes.VoteCount = _presidentialVotes.VoteCount + 1;
                    _context.PresidentialVotes.Update(_presidentialVotes);
                    _context.SaveChanges();
                }
                UpdateVotedPresidentialCandidate(model);
                return true;

            }
            throw new AppException("User already voted");
        }

        public IEnumerable<PresidentialVoteResponse> GetAll()
        {
            var presidentialVotes = _context.PresidentialVotes;
            return _mapper.Map<IList<PresidentialVoteResponse>>(presidentialVotes);
        }

        public PresidentialVoteResponse GetPresidentialVoteById(int id)
        {
            var _presidentialVote = getPresidentialVoteById(id);
            return _mapper.Map<PresidentialVoteResponse>(_presidentialVote);
        }


        public void Delete(int id)
        {
            var _presidentialVote = getPresidentialVoteById(id);
            if (_presidentialVote != null)
            {
                _context.PresidentialVotes.Remove(_presidentialVote);
                _context.SaveChanges();
            }
        }

        private PresidentialVote getPresidentialVoteByCandidateId(int PresId)
        {
            try
            {
                var user = _context.PresidentialVotes.FirstOrDefault(x => x.PresidentialCandidateId == PresId);
                if (user == null) return null;
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private PresidentialVote getPresidentialVoteById(int id)
        {
            var _PresidentialVote = _context.PresidentialVotes.Find(id);
            return _PresidentialVote;
        }

        private bool getCheckUserAlreadyVoted(int userId)
        {
            try
            {
                var user = _context.Users.Find(userId);
                if (user == null) throw new AppException("User not found. Please try again");
                if (user.IsPresidentialCandidateVoted == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        private void UpdateVotedPresidentialCandidate(PresidentialVoteRequest model)
        {
            var user = _context.Users.Find(model.UserId);
            user.IsPresidentialCandidateVoted = true;
            user.PresidentialCandidateId = model.PresidentialCandidateId;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}