namespace WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int LocalAreaId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int? PresidentialCandidateId { get; set; }
        public bool? IsPresidentialCandidateVoted { get; set; }
        public int? GovernorCandidateId { get; set; }
        public bool? IsGovernorCandidateVoted { get; set; }
        public PresidentialCandidate PresidentialCandidate { get; set; }
        public GovernorCandidate GovernorCandidate { get; set; }
        public LocalArea LocalArea { get; set; }
    }
}