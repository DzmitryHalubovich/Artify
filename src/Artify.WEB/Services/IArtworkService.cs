using Artify.WEB.Models;

namespace Artify.WEB.Services
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkModel>> GetArtworks();
        Task<IEnumerable<ArtworkModel>> GetArtworksForAuthor(Guid authorId);
        Task<ArtworkModel> GetArtwork(Guid id);
        Task CreateArtwork(ArtworkCreateModel product);
        Task<string> UploadProductImage(MultipartFormDataContent content);

        Task DeleteArtwork(Guid authorId, Guid artworkId);
        Task<AuthorModel> GetAuthor(Guid authorId);
    }
}
