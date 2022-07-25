using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        // [Required]
        // [EmailAddress]
        // public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}