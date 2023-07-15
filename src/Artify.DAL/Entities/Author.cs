using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artify.DAL.Entities
{
    public class Author
    {
        [Column("AuthorId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Author name is a required field.")]
        public string Name { get; set; }

        public ICollection<Artwork>? Artworks { get; set; }
    }
}
