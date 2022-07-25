using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Artisan
{
    public class PhotoRequest
    {
        [Required]
        public string Photo { get; set; }
    }
}