using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Artisan
{
    public class UpdatePaymentRequest
    {
        [Required]
        public int Ratings { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        [Required]
        public DateTime? DateApproved { get; set; }
    }
}