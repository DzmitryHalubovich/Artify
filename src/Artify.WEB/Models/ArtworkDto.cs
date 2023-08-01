namespace Artify.WEB.Models
{
    public class ArtworkDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        public string ImageUrl { get; set; } = default!;
    }
}
