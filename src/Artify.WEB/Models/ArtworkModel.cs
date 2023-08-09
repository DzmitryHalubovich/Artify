namespace Artify.WEB.Models
{
    public class ArtworkModel
    {
        public Guid ArtworkId { get; set; }
        public AuthorModel Author { get; set; } = new AuthorModel();
        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        public string ImageUrl { get; set; } = default!;
    }
}
