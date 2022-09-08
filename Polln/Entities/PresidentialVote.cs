
namespace WebApi.Entities
{
    public class PresidentialVote
    {
        public int Id { get; set; }
        public int PresidentialCandidateId { get; set; }
        public PresidentialCandidate PresidentialCandidate { get; set; }
        public int VoteCount { get; set; }
    }
}