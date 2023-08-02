using Microsoft.AspNetCore.Identity;

namespace Artify.Entities.Models
{
    public class Author : IdentityUser
    {
        public ICollection<Artwork>? Artworks { get; set; }
    }
}
