using Microsoft.AspNetCore.Http;

namespace Artify.Entities.DTO
{
    public record ArtworkForCreationDto(string ArtworkName, string? Description, IFormFile Image);
}
