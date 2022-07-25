
namespace WebApi.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Photo { get; set; }
        public Account Account { get; set; }

    }
}
