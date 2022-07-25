using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.SMS
{
    public class SMSRequest
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }
    }

    public class ContactRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}