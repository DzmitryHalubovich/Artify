﻿using Artify.WEB.Models;

namespace Artify.WEB.Services
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkModel>> GetArtworks();
        Task<ArtworkModel> GetArtwork(Guid id);
        Task CreateArtwork(ArtworkCreateModel product);
        Task<string> UploadProductImage(MultipartFormDataContent content);

    }
}
