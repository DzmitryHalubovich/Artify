using System.ComponentModel.DataAnnotations;

namespace Artify.Entities.DTO
{
    public record AuthorForCreationDto 
    {
        [Required(ErrorMessage = "Author name is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]
        public string Name { get; init; }
    }

}
