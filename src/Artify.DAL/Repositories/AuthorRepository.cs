using Artify.Entities.Models;
using Artify.Repositories.Contracts;

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
