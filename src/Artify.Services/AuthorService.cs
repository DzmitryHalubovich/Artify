using Artify.Entities.DTO;
using Artify.Entities.Exceptions;
using Artify.Entities.Models;
using Artify.Repositories.Contracts;
using Artify.Services.Contracts;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Artify.Services
{
    public sealed class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthorService(IRepositoryManager repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public  AuthorDto Create(AuthorForCreationDto author)
         {
            var authorForDb = _mapper.Map<Author>(author);
            
           var authorStoragePath = CreateAuthorFoulderIfNotExistsAsync(author);

            authorForDb.StoragePath = authorStoragePath;

            _repository.Author.Create(authorForDb);
            _repository.Save();

            var authorToReturn = _mapper.Map<AuthorDto>(authorForDb);

            return authorToReturn;
        }

        private string CreateAuthorFoulderIfNotExistsAsync(AuthorForCreationDto author)
        {
            string localImagesStoragePath = _configuration.GetSection("LocalImageStorage").Value!;

            var currentProjectDirectory = Directory.GetCurrentDirectory() + localImagesStoragePath;

            var localAuthorFoulderWithImages = new DirectoryInfo(Path.Combine(currentProjectDirectory, author.Name));

            if (!localAuthorFoulderWithImages.Exists)
                localAuthorFoulderWithImages.Create();

            return localAuthorFoulderWithImages.FullName;
        }

        public async void Delete(Guid authorId, bool trackChanges)
        {
            var author = _repository.Author.Get(authorId, trackChanges);
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            _repository.Author.Delete(author);
            _repository.Save();
        }

        public AuthorDto Get(Guid authorId, bool trackChanges)
        {
            var author = _repository.Author.Get(authorId, trackChanges);
            
            if (author is null)
                throw new AuthorNotFoundException(authorId);

            var returnAuthor = _mapper.Map<AuthorDto>(author);

            return returnAuthor;
        }

        public IEnumerable<AuthorDto> GetAll(bool trackChanges)
        {
            var authors = _repository.Author.GetAllAuthors(trackChanges);

            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorsDto;
        }
    }
}
