namespace Artify.WEB.Models
{
    public class ArtworkModel
    {
        public Guid ArtworkId { get; set; }
        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        public string ImageUrl { get; set; } = default!;
    }
}
