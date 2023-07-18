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

        public async Task<ArtworkDto> Create(ArtworkForCreationDto artwork)
        {
            string localImagesStoragePath = _configuration.GetSection("LocalImageStorage").Value;

            string authorLocalStoragePath = Path.Combine(localImagesStoragePath, artwork.AuthorName);

            var authorImagesDirectory = new DirectoryInfo(authorLocalStoragePath); //Delete

            var currentProjectDirectory = Directory.GetCurrentDirectory() + localImagesStoragePath;
            
            var localAuthorFoulderWithAimages = new DirectoryInfo(Path.Combine(currentProjectDirectory, artwork.AuthorName));

            if (!localAuthorFoulderWithAimages.Exists)
                localAuthorFoulderWithAimages.Create();

            string path = Path.Combine(currentProjectDirectory, artwork.AuthorName, artwork.Image.FileName);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await artwork.Image.CopyToAsync(stream);
            }

            var pathForDatabase = Path.Combine("ArtWorkCollection", artwork.AuthorName, artwork.Image.FileName);

            var artworkEntity = _mapper.Map<Artwork>(artwork);

            artworkEntity.ImagePath = pathForDatabase;

            var author = FindAuthorByName(artwork.AuthorName);

            artworkEntity.AuthorId = author.Id;

            _repository.Artwork.CreateNew(artworkEntity);
            _repository.Save();

            var artworkToReturn = _mapper.Map<ArtworkDto>(artworkEntity);

            return artworkToReturn;
        }


        private Author FindAuthorByName(string authorName) =>
            _repository.Author.GetByName(authorName);
    }
}
