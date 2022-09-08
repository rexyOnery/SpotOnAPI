namespace WebApi.Entities
{
    public class GovernorVote
    {
        public int Id { get; set; }
        public int GovernorCandidateId { get; set; }
        public GovernorCandidate GovernorCandidate { get; set; }
        public int VoteCount { get; set; }
    }
}