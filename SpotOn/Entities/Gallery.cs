
namespace WebApi.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Photo { get; set; }
        public string DateAdded { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Account Account { get; set; }

    }
}
