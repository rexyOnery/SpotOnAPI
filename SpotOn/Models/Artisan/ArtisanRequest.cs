using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Artisan
{
    public class ArtisanRequest
    {
        [Required]
        public int ArtisanTypeId { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int LocalAreaId { get; set; }
        [Required]
        public string Location { get; set; }
    }
}