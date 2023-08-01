using Artify.Entities.Models;

namespace Artify.Repositories.Contracts
{
    public interface IArtworkRepository
    {
        Task<IEnumerable<Artwork>> GetAllAsync(bool trackChanges);
        Task<IEnumerable<Artwork>> GetAllForAuthorAsync(Guid authorId, bool trackChanges);
        Task<Artwork> GetByIdAsync(Guid artworkId, bool trackChanges);
        void CreateNewForAuthor(Guid authorId ,Artwork artwork);
        void Delete(Artwork artwork);
    }
}
