using Microsoft.AspNetCore.Identity;

namespace Artify.Entities.Models
{
    public class Author: IdentityUser<Guid>
    {
        public required AuthorProfile Profile { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
