using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artify.Entities.Models
{
    public class Artwork
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        public string ImageUrl { get; set; } = default!;
    }
}
