using Artify.Entities.DTO;
using Artify.Entities.Models;
using AutoMapper;

namespace Artify.API.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Author, AuthorDto>();
        }
    }
}
