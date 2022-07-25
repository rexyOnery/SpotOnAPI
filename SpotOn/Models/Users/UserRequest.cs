using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class UserRequest
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int LocalAreaId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Location { get; set; }
    }
}