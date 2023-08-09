using Artify.DAL;
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
            .Include(x=>x.Author)
            .OrderBy(x => x.ArtworkId)
            .ToListAsync();

        public async Task<Artwork> GetByIdAsync(Guid artworkId, bool trackChanges) =>
            await FindByCondition(a => a.ArtworkId.Equals(artworkId), trackChanges)
                .Include(x=>x.Author)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Artwork>> GetAllForAuthorAsync(Guid authorId, bool trackChanges) =>
           await FindByCondition(a => a.AuthorId.Equals(authorId.ToString()), trackChanges: false)
                .OrderByDescending(x => x.ArtworkId)
                .ToListAsync();

        public void CreateNewForAuthor(Guid authorId, Artwork artwork)
        {
            artwork.AuthorId = authorId.ToString();
            CreateEntity(artwork);
        }

        public void Delete(Artwork artwork) => DeleteEntity(artwork);
    }
}
