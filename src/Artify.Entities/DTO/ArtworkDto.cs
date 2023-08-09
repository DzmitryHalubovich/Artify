namespace Artify.Entities.DTO
{
    public record ArtworkDto
    {
        public Guid ArtworkId { get; init; }
        public AuthorDto Author { get; init; }
        public required string Title { get; init; } 
        public string? Description { get; init; }
        public required string ImageUrl { get; init; }
    }
}
