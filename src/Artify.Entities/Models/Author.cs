using Microsoft.AspNetCore.Identity;

namespace Artify.Entities.Models
{
    public class Author : IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Artwork>? Artworks { get; set; }
    }
}
