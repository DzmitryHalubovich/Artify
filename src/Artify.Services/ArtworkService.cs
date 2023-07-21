using Artify.Entities.DTO;
using Artify.Entities.Exceptions;
using Artify.Entities.Models;
using Artify.Repositories.Contracts;
using Artify.Services.Contracts;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Artify.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public ArtworkService(IRepositoryManager repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration=configuration;
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

        public async Task<ArtworkDto> CreateForAuthor(Guid authorId, ArtworkForCreationDto artwork, bool trackChanges)
        {
            var author = _repository.Author.Get(authorId, trackChanges);

            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var artworkInDb = _repository.Artwork.GetByName(artwork.ArtworkName, false);

            if (artworkInDb is not null)
                throw new ArtworkAlreadyExistsException(artwork.ArtworkName);

            string path = Path.Combine(author.StoragePath, artwork.Image.FileName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await artwork.Image.CopyToAsync(stream);
            }

            var pathForDatabase = Path.Combine(_configuration.GetSection("LocalImageStorageName").Value!, author.Name, artwork.Image.FileName);

            var artworkEntity = _mapper.Map<Artwork>(artwork);

            artworkEntity.ImagePath = pathForDatabase;
            artworkEntity.ImageFileName = artwork.Image.FileName;

            _repository.Artwork.CreateNewForAuthor(authorId,artworkEntity);
            _repository.Save();

            var artworkToReturn = _mapper.Map<ArtworkDto>(artworkEntity);

            return artworkToReturn;
        }

        public void Delete(Guid authorId, Guid artworkId, bool trackChanges)
        {
            var author = _repository.Author.Get(authorId, trackChanges);
            if  (author is null)
            {
                throw new AuthorNotFoundException(authorId);
            }

            var artwork = _repository.Artwork.Get(artworkId, trackChanges);

            if (artwork is null)
            {
                throw new ArtworkNotFoundException(artworkId);
            }

            var path = Path.Combine(author.StoragePath, artwork.ImageFileName);
            var localImageCopy = new FileInfo(path);

            if (localImageCopy.Exists)
            {
                localImageCopy.Delete();
            }

            _repository.Artwork.Delete(artwork);
            _repository.Save();
        }
    }
}
