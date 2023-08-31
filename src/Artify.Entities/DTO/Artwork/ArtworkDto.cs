using Artify.Entities.Models;

namespace Artify.Entities.DTO.Artwork
{
    public record ArtworkDto
    {
        public Guid ArtworkId { get; init; }
        public Guid AuthorId { get; set; }
        public AuthorProfile AuthorProfile { get; init; }
        public string Title { get; init; }
        public string? Description { get; init; }
        public string ImageUrl { get; init; }

        public DateTime Created { get; set; }

        public int Likes { get; set; }

        public int Views { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
