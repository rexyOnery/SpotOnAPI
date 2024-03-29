using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Gallery
{
    public class GalleryRequests
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}