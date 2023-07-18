using Artify.Entities.DTO;

namespace Artify.WEB.Services.Contracts
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkDto>> GetArtworks();

    }
}
