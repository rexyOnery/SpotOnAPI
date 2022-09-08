using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class UserRequest
    {
        [Required]
        public int LocalAreaId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UserRequestByPhone
    {
        public string Phone { get; set; }
    }
}