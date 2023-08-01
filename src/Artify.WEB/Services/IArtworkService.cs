using Artify.Entities.Models;
using Artify.WEB.Models;

namespace Artify.WEB.Services
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkDto>> GetArtworks();
        Task CreateArtwork(Artwork product);
        Task<string> UploadProductImage(MultipartFormDataContent content);

    }
}
