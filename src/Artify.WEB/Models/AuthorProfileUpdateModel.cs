using System.ComponentModel.DataAnnotations;

namespace Artify.WEB.Models
{
    public class AuthorProfileUpdateModel
    {
        [Required(ErrorMessage = "Field Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Profession is required.")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Fireld City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Field Country is required.")]
        public string Country { get; set; }

        public string AvatarUrl { get; set; }
    }
}
