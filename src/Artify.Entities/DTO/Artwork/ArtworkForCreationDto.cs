using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Artify.Entities.DTO.Artwork
{
    public record ArtworkForCreationDto
    {
        [Required(ErrorMessage = "Artwork title is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Title is 100 characters.")]
        public string Title { get; init; }
        [MaxLength(512, ErrorMessage = "Maximum length for the Descritption is 512 characters.")]
        public string? Description { get; init; }
        [Required(ErrorMessage = "Image is a required field.")]
        public string ImageUrl { get; init; }
    }
}
