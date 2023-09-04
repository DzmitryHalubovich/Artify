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


        public async Task DeleteAsync(Guid authorId, bool trackChanges)
        {
            var author = await _repository.Author.GetByIdAsync(authorId, trackChanges);
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            _repository.Author.Delete(author);
            await _repository.SaveAsync();
        }

        public async Task<AuthorDto> GetByIdAsync(Guid authorId, bool trackChanges)
        {
            var author = await _repository.Author.GetByIdAsync(authorId, trackChanges);
            
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var returnAuthor = _mapper.Map<AuthorDto>(author);

            return returnAuthor;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync(bool trackChanges)
        {
            var authors = await _repository.Author.GetAllAuthorsAsync(trackChanges);

            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorsDto;
        }
    }
}
