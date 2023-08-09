using Artify.Entities.Models;
using Artify.WEB.Models;

namespace Artify.WEB.Services
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkDto>> GetArtworks();
        Task<ArtworkDto> GetArtwork(Guid id);
        Task CreateArtwork(ArtworkCreateModel product);
        Task<string> UploadProductImage(MultipartFormDataContent content);

    }
}
