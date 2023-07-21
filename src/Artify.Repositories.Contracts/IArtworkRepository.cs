using Artify.Entities.Models;

namespace Artify.Repositories.Contracts
{
    public interface IArtworkRepository
    {
        IEnumerable<Artwork> GetAll(bool trackChanges);
        IEnumerable<Artwork> GetAllForAuthor(Guid authorId, bool trackChanges);
        Artwork Get(Guid artworkId, bool trackChanges);
        Artwork GetByName(string name, bool trackChanges);
        void CreateNewForAuthor(Guid authorId ,Artwork artwork);
        void Delete(Artwork artwork);
    }
}
