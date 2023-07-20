namespace Artify.Entities.DTO
{
    public record ArtworkDto
    {
        public Guid Id { get; init; }
        public required string Name { get; init; } 
        public string? Description { get; init; }
        public required string ImagePath { get; init; }
    }
}
