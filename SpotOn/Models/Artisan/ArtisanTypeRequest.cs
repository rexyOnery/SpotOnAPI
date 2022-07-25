using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Artisan
{
    public class ArtisanTypeRequest
    {
        [Required]
        public string Category { get; set; }
    }
}