using Artify.Entities.DTO;
using Artify.Entities.Models;
using AutoMapper;

namespace Artify.API.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();

            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<Author, AuthorForCreationDto>();

            CreateMap<Artwork, ArtworkDto>();
            CreateMap<ArtworkForCreationDto, Artwork>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
