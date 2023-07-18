using Artify.DAL;
using Artify.Entities.Models;
using Artify.Repositories.Contracts;

namespace Artify.Repository.Repositories
{
    public class ArtworkRepository : RepositoryBase<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Artwork> GetAll(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(x => x.Id)
                .ToList();

        public Artwork Get(Guid artworkId, bool trackChanges) =>
            FindByCondition(a => a.Id.Equals(artworkId), trackChanges)
                .SingleOrDefault();

        public IEnumerable<Artwork> GetAllForAuthor(Guid authorId, bool trackChanges) =>
            FindByCondition(a => a.AuthorId.Equals(authorId), trackChanges: false)
                .OrderBy(x => x.Id)
                .ToList();

        public void CreateNew(Artwork artwork) =>
            Create(artwork);

        public Artwork GetByName(string name, bool trackChanges) =>
            FindByCondition(a => a.Name.Equals(name), trackChanges)
            .SingleOrDefault();
    }
}
