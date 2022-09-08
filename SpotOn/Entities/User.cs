using System.Collections.Generic;

namespace WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int LocalAreaId { get; set; }
        public string Name { get; set; }
        //public string Photo { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public Account Account { get; set; }
        public LocalArea LocalArea { get; set; }
    }
}