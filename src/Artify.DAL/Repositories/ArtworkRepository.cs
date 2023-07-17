using Artify.DAL;
using Artify.Entities.Models;
using Artify.Repositories.Contracts;

namespace Artify.Repository.Repositories
{
    public class ArtworkRepository : RepositoryBase<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    }
}
