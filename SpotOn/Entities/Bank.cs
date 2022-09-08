using System;

namespace WebApi.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool isPaid { get; set; }
        public string BankName { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public Artisan Artisan { get; set; }
    }
}