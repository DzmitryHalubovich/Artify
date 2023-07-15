using Artify.Contracts.Repositories;
using Artify.DAL;

namespace Artify.BusinessLogic.Repositories
{
    public class AuthorRepository : RepositoryBase<AuthorRepository>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    }
}
