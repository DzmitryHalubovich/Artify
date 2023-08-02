using System.ComponentModel.DataAnnotations;

namespace Artify.WEB.Models
{
    public class UserForAuthentication
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }
    }
}
