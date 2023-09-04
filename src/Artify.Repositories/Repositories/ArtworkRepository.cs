using Artify.Entities.Models;
using Artify.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Artify.Repository.Repositories
{
    public class ArtworkRepository : RepositoryBase<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Artwork>> GetAllAsync(bool trackChanges) => 
            await FindAll(trackChanges)
            .OrderBy(x => x.ArtworkId)
            .ToListAsync();

        public async Task<Artwork> GetByIdAsync(Guid artworkId, bool trackChanges) =>
            await FindByCondition(a => a.ArtworkId.Equals(artworkId), trackChanges)
                .Include(x=>x.AuthorProfile)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Artwork>> GetAllForAuthorAsync(Guid authorId, bool trackChanges) =>
           await FindByCondition(a => a.AuthorId.Equals(authorId), trackChanges: false)
                .OrderByDescending(x => x.ArtworkId)
                .ToListAsync();

        public async Task CreateNewForAuthor(Guid authorId, Artwork artwork)
        {
            artwork.AuthorId = authorId;
            artwork.Created = DateTime.Now;
            await CreateEntity(artwork);
        }

        public void Delete(Artwork artwork) => DeleteEntity(artwork);
    }
}
