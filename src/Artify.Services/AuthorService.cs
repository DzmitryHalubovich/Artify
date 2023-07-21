using Artify.Entities.DTO;
using Artify.Entities.Exceptions;
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

        public async void Delete(Guid authorId, bool trackChanges)
        {
            var author = _repository.Author.Get(authorId, trackChanges);
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            _repository.Author.Delete(author);
            _repository.Save();
        }

        public IEnumerable<AuthorDto> GetAll(bool trackChanges)
        {
            var authors = _repository.Author.GetAllAuthors(trackChanges);

            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorsDto;
        }
    }
}
