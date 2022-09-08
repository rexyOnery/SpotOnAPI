using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.PresidentialCandidate
{
    public class PresidentialCandidateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Party { get; set; }
    }
}