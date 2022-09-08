namespace WebApi.Models.Users
{
    public class UserResponse
    {
        public int Id { get; set; }
        public int LocalAreaId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int GovernorCandidateId { get; set; }
        public int PresidentialCandidateId { get; set; }
        public bool IsGovernorCandidateVoted { get; set; }
        public bool IsPresidentialCandidateVoted { get; set; }
    }
}