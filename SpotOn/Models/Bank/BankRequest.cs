using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Bank
{
    public class BankRequest
    {
        [Required]
        public int ArtisanId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string BankAccountName { get; set; }
        [Required]
        public string BankAccountNumber { get; set; }

    }
}