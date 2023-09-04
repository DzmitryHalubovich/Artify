using System.ComponentModel.DataAnnotations.Schema;

namespace Artify.Entities.DTO.Artwork
{
    public class ArtworkDetailsDto
    {
        public Guid ArtworkId { get; set; }

        public Guid AuthorId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Created {  get; set; }

        public int Likes { get; set; }

        public int Views { get; set; }


        //Author profile 

        public string AuthorPublicName { get; set; }

        public string Profession { get; set; }

    }
}
