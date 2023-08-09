using Artify.Entities.DTO;
using Artify.Entities.DTO.Artwork;
using Artify.Entities.DTO.Authorization;
using Artify.Entities.Models;
using AutoMapper;

namespace Artify.API.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, Author>();
            CreateMap<Author, UserForAuthenticationDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));

            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<Author, AuthorForCreationDto>();

            CreateMap<Artwork, ArtworkDto>()
                .ForPath(dest => dest.Author.Id, opt => opt.MapFrom(src => Guid.Parse(src.Author.Id)))
                .ForPath(dest => dest.Author.Name, opt => opt.MapFrom(src => src.Author.Name));

            CreateMap<ArtworkForCreationDto, Artwork>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
