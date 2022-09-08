using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Artisan
{
    public class ReferrerCodeRequest
    {
        [Required]
        public string ReferrerCode { get; set; }
    }
}