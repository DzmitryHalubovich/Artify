using Artify.Entities.DTO;
using Artify.Repositories.Contracts;
using Artify.Services.Contracts;
using AutoMapper;

namespace Artify.Services
{
    public sealed class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public AuthorService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<AuthorDto> GetAll(bool trackChanges)
        {
           
            var authors = _repository.Author.GetAllAuthors(trackChanges);

            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorsDto;
            
        }

    }
}
