namespace Artify.WEB.Models
{
    public class ArtworkModel
    {
        public Guid ArtworkId { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorProfile AuthorProfile { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }

        public DateTime Created { get; set; }

        public int Likes { get; set; }

        public int Views { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
