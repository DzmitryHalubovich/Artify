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
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));

            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<Artwork, ArtworkDto>();
            CreateMap<Artwork, ArtworkDetailsDto>()
                .ForMember(dest => dest.AuthorPublicName, opt => opt.MapFrom(src => src.AuthorProfile.Name))
                .ForMember(dest => dest.Profession, opt => opt.MapFrom(src => src.AuthorProfile.Profession))
                .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.AuthorProfile.AvatarUrl))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created.ToString()));


            CreateMap<AuthorProfileUpdateDto, AuthorProfile>();

            CreateMap<ArtworkForCreationDto, Artwork>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
