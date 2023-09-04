using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artify.Entities.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }

        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public required AuthorProfile AuthorProfile { get; set; }

        [MaxLength(512, ErrorMessage = "Maximum length for the Descritption is 512 characters.")]
        public required string CommentText { get; set; }
    }
}
