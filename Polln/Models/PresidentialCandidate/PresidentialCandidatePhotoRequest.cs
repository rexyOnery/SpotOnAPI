using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.PresidentialCandidate
{
    public class PresidentialCandidatePhotoRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Photo { get; set; }
    }
}