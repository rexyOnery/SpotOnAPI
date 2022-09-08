namespace WebApi.Models.PresidentialVote
{
    public class PresidentialVoteResponse
    {
        public int Id { get; set; }
        public int PresidentialCandidateId { get; set; }
        public int VoteCount { get; set; }
    }
}