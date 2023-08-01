﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artify.Entities.Models
{
    public class Artwork
    {
        [Column("ArtworkId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "Artwork title is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Title is 100 characters.")]
        public string Title { get; set; } = default!;

        [MaxLength(512, ErrorMessage = "Maximum length for the Descritption is 512 characters.")]
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = default!;
    }
}
