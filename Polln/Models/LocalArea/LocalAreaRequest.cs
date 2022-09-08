using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.LocalArea
{
    public class LocalAreaRequest
    {
        [Required]
        public int StateId { get; set; }
        [Required]
        public string LocationName { get; set; }
    }
}