using Artify.Entities.DTO;

namespace Artify.Services.Contracts
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkDto>> GetAllAsync(bool trackChanges);
        Task<IEnumerable<ArtworkDto>> GetAllForAuthorAsync(Guid authorId, bool trackChanges);
        Task<ArtworkDto> GetByIdAsync(Guid artworkId, bool trackChanges);
        Task<ArtworkDto> CreateForAuthorAsync(Guid authorId, 
            ArtworkForCreationDto artwork, bool trackChanges);

        Task DeleteAsync(Guid authorId, Guid artworkId, bool trackChanges);
    }
}
