using Microsoft.AspNetCore.Identity;

namespace Artify.Entities.Models
{
    public class Author : IdentityUser
    {
        public string PublicName { get; set; }
        public ICollection<Artwork>? Artworks { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
