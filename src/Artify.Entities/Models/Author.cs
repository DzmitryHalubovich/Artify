using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artify.Entities.Models
{
    public class Author
    {
        [Column("AuthorId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Author name is a required field.")]
        public string Name { get; set; }
        public required string StoragePath { get; set; }

        public ICollection<Artwork>? Artworks { get; set; }
    }
}
