using Artify.Entities.Models;

namespace Artify.Repositories.Contracts
{
    public interface IArtworkRepository
    {
        IEnumerable<Artwork> GetAll(bool trackChanges);
        IEnumerable<Artwork> GetAllForAuthor(Guid authorId, bool trackChanges);
        Artwork Get(Guid artworkId, bool trackChanges);

        //Not sure about this
        Artwork GetArtwork(Guid authorId, Guid artworkId, bool trackChanges);
    }
}
