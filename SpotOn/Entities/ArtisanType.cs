using System.Collections.Generic;

namespace WebApi.Entities
{
    public class ArtisanType
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public ICollection<Artisan> Artisans { get; set; }
    }
}