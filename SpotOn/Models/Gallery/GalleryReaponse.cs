namespace WebApi.Models.Gallery
{
    public class GalleryResponse
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string DateAdded { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}