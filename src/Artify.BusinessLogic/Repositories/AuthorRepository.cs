using Artify.Contracts.Repositories;
using Artify.DAL;
using Artify.DAL.Entities;

namespace Artify.BusinessLogic.Repositories
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
