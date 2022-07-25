using System.ComponentModel.DataAnnotations;
namespace WebApi.Models.Artisan
{
    public class ArtisanFilterRequest
    {
        [Required]
        public int LocalAreaId { get; set; }
        [Required]
        public string Location { get; set; }
        public int ArtisanTypeId { get; set; }
    }
}