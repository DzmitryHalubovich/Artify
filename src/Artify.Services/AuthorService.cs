using Artify.Contracts.Repositories;
using Artify.Contracts.Services;
using Artify.Entities.Models;

namespace Artify.Services
{
    public sealed class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        public AuthorService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<Author> GetAll(bool trackChanges)
        {
            try
            {
                var authors = _repository.Author.GetAllAuthors(trackChanges);

                return authors;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
