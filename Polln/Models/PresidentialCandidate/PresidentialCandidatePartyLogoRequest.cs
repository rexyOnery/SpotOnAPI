using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.PresidentialCandidate
{
    public class PresidentialCandidatePartyLogoRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PartyLogo { get; set; }
    }
}