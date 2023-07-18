using Microsoft.AspNetCore.Http;

namespace Artify.Entities.DTO
{
    public record ArtworkForCreationDto(string AuthorName, string ArtworkName, string? Description, IFormFile Image);
}
