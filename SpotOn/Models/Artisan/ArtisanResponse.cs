using System;

namespace WebApi.Models.Artisan
{
    public class ArtisanResponse
    {
        public int Id { get; set; }
        public int ArtisanTypeId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public int Ratings { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? DateApproved { get; set; }
    }
}