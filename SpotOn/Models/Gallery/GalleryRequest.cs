using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Gallery
{
    public class GalleryRequests
    {
        [Required]
        public string Photo { get; set; }
    }
}