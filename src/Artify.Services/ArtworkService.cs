using Artify.Entities.DTO;
using Artify.Entities.Exceptions;
using Artify.Repositories.Contracts;
using Artify.Services.Contracts;
using AutoMapper;

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

        public IEnumerable<ArtworkDto> GetAll(bool trackChanges)
        {
            var artworks = _repository.Artwork.GetAll(trackChanges);

            var artworksDto = _mapper.Map<IEnumerable< ArtworkDto>>(artworks);

            return artworksDto;
        }

        public ArtworkDto Get(Guid id, bool trackChanges)
        {
            var artwork = _repository.Artwork.Get(id, trackChanges);

            if (artwork is null)
                throw new ArtworkNotFoundException(id);

            var artworkDto = _mapper.Map<ArtworkDto>(artwork);

            return artworkDto;
        }

        public IEnumerable<ArtworkDto> GetAllForAuthor(Guid authorId, bool trackChanges)
        {
            var author = _repository.Author.Get(authorId, trackChanges);

            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var artworks = _repository.Artwork.GetAllForAuthor(authorId, trackChanges);

            var artworksDto = _mapper.Map<IEnumerable<ArtworkDto>>(artworks);

            return artworksDto;
        }

        public ArtworkDto GetArtwork(Guid authorId, Guid artworkId, bool trackChanges)
        {
            var author = _repository.Author.Get(authorId,trackChanges);

            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var artworkDto = _repository.Artwork.GetArtwork(authorId, artworkId, trackChanges);
            if (artworkDto is null)
                throw new ArtworkNotFoundException(artworkId);

            var artwork = _mapper.Map<ArtworkDto>(artworkDto);

            return artwork;
        }
    }
}
