using Artify.WEB.Models.Artwork;

namespace Artify.WEB.Services.Interfaces
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkDetailsModel>> GetArtworks();
        Task<IEnumerable<ArtworkDetailsModel>> GetArtworksForAuthor(Guid authorId);
        Task<ArtworkDetailsModel> GetArtwork(Guid id);
        Task CreateArtwork(ArtworkCreateModel product);
        Task<string> UploadProductImage(MultipartFormDataContent content);

        Task DeleteArtwork(Guid authorId, Guid artworkId);
        Task<AuthorModel> GetAuthor(Guid authorId);
    }
}
