using System.ComponentModel.DataAnnotations;

namespace Artify.WEB.Models
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; set; }
    }
}
