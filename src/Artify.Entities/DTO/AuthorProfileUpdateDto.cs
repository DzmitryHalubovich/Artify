using System.ComponentModel.DataAnnotations;

namespace Artify.Entities.DTO
{
    public class AuthorProfileUpdateDto
    {
        [Required(ErrorMessage = "Field Name is required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Field Profession is required.")]
        public required string Profession { get; set; }

        [Required(ErrorMessage = "Fireld City is required.")]
        public required string City { get; set; }

        [Required(ErrorMessage = "Field Country is required.")]
        public required string Country { get; set; }
    }
}
