using Microsoft.AspNetCore.Http;

namespace Artify.Entities.DTO
{
    public record ArtworkForCreationDto(Guid AuthorId, string ArtworkName, string? Description, IFormFile Image);
}
