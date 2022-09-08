using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.PresidentialVote
{
    public class PresidentialVoteRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PresidentialCandidateId { get; set; }
    }
}