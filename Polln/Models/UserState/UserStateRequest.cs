using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.UserState
{
    public class UserStateRequest
    {
        [Required]
        public string StateName { get; set; }
    }
}