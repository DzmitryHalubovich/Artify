using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Artify.Entities.DTO.Authorization
{
    public class UserForRegistrationDto
    {

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        public ICollection<string>? Roles = new List<string>();
    }
}
