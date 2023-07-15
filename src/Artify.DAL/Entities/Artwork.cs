using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artify.DAL.Entities
{
    public class Artwork
    {
        [Column("ArtworkId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "Artwork name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string Name { get; set; }

        [MaxLength(512, ErrorMessage = "Maximum length for the Descritption is 512 characters.")]
        public string? Description { get; set; }

        public string ImagePath { get; set; }
    }
}
