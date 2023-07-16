using Artify.Contracts.Repositories;
using Artify.DAL;
using Artify.Entities.Models;

namespace Artify.Repository.Repositories
{
    public class ArtworkRepository : RepositoryBase<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    }
}
