using Artify.Contracts.Repositories;
using Artify.Entities.Models;

namespace Artify.Repository.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Author> GetAllAuthors(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c=>c.Name)
                .ToList();
    }
}
