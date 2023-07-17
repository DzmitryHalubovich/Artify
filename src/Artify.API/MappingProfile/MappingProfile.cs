using Artify.Entities.DTO;
using Artify.Entities.Models;
using AutoMapper;

namespace Artify.API.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Artwork, ArtworkDto>();
        }
    }
}
