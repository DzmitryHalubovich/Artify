namespace Artify.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public ArtworkService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtworkDto>> GetAllAsync(bool trackChanges)
        {
            var artworks = await _repository.Artwork.GetAllAsync(trackChanges);

            var artworksDto = _mapper.Map<IEnumerable< ArtworkDto>>(artworks);

            return artworksDto;
        }

        public async Task<ArtworkDto> GetByIdAsync(Guid id, bool trackChanges)
        {
            var artwork = await _repository.Artwork.GetByIdAsync(id, trackChanges);

            if (artwork is null)
                throw new ArtworkNotFoundException(id);
            
            var artworkDto = _mapper.Map<ArtworkDto>(artwork);

            return artworkDto;
        }

        public async Task<IEnumerable<ArtworkDto>> GetAllForAuthorAsync(Guid authorId, bool trackChanges)
        {
            var author = await _repository.Author.GetByIdAsync(authorId, trackChanges);

            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var artworks = await _repository.Artwork.GetAllForAuthorAsync(authorId, trackChanges);

            var artworksDto = _mapper.Map<IEnumerable<ArtworkDto>>(artworks);

            return artworksDto;
        }

        public async Task<ArtworkDto> CreateForAuthorAsync(Guid authorId, ArtworkForCreationDto artwork, bool trackChanges)
        {
            var author = await _repository.Author.GetByIdAsync(authorId, trackChanges);

            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var artworkEntity = _mapper.Map<Artwork>(artwork);
            _repository.Artwork.CreateNewForAuthor(authorId,artworkEntity);
            await _repository.SaveAsync();

            var artworkToReturn = _mapper.Map<ArtworkDto>(artworkEntity);

            return artworkToReturn;
        }

        public async Task DeleteAsync(Guid authorId, Guid artworkId, bool trackChanges)
        {
            var artwork = await _repository.Artwork.GetByIdAsync(artworkId, trackChanges);

            if (artwork is null)
            {
                throw new ArtworkNotFoundException(artworkId);
            }

            _repository.Artwork.Delete(artwork);
            await _repository.SaveAsync();
        }
    }
}
