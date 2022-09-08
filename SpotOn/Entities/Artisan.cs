using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Artisan
    {
        public int Id { get; set; }
        public int ArtisanTypeId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public int LocalAreaId { get; set; }
        public string Location { get; set; }
        public int Ratings { get; set; }
        public bool IsApproved { get; set; }
        public string RefererCode { get; set; }
        public int RefererCount { get; set; }
        public DateTime? DateApproved { get; set; }
        public ArtisanType ArtisanType { get; set; }
        public Account Account { get; set; }
        public LocalArea LocalArea { get; set; }

        public ICollection<Bank> Banks { get; set; }
    }
}