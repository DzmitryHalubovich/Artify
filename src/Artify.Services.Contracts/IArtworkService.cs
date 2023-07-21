using Artify.Entities.DTO;

namespace Artify.Services.Contracts
{
    public interface IArtworkService
    {
        IEnumerable<ArtworkDto> GetAll(bool trackChanges);
        IEnumerable<ArtworkDto> GetAllForAuthor(Guid authorId, bool trackChanges);
        ArtworkDto Get(Guid artworkId, bool trackChanges);
        Task<ArtworkDto> CreateForAuthor(Guid authorId, 
            ArtworkForCreationDto artwork, bool trackChanges);

        void Delete(Guid authorId, Guid artworkId, bool trackChanges);
    }
}
