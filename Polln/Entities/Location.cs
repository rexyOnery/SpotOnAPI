namespace WebApi.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public int LocalAreaId { get; set; }
        public string LocationName { get; set; }
        public LocalArea LocalArea { get; set; }
    }
}