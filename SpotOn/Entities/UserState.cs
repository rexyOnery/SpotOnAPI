using System.Collections.Generic;

namespace WebApi.Entities
{
    public class UserState
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public ICollection<LocalArea> LocalAreas { get; set; }
    }
}