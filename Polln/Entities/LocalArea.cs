
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class LocalArea
    {
        public int Id { get; set; }
        public int UserStateId { get; set; }
        public string LocationName { get; set; }
        public UserState UserState { get; set; }
        public ICollection<Location> Locations { get; set; }
        //public ICollection<Artisan> Artisans { get; set; }
        public ICollection<User> Users { get; set; }
    }
}