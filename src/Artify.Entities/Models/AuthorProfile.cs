using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artify.Entities.Models
{
    public class AuthorProfile
    {
        [Key]
        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }

        public required string Name { get; set; }

        public required string Profession { get; set; }

        public required string City { get; set; } 

        public required string Country { get; set; }

        public ICollection<Artwork>? Artworks { get; set; }
    }
}
