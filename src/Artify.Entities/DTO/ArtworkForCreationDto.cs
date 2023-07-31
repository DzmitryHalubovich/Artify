using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Artify.Entities.DTO
{
    public record ArtworkForCreationDto
    {
        [Required(ErrorMessage = "Artwork name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string ArtworkName { get; init; }
        [MaxLength(512, ErrorMessage = "Maximum length for the Descritption is 512 characters.")]
        public string? Description { get; init; }
        [Required(ErrorMessage = "Image is a required field.")]
        public IFormFile Image { get; init; }
    }
}
