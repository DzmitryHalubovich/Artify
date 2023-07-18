using Artify.Entities.DTO;
using Artify.WEB.Services.Contracts;
using System.Net.Http.Json;

namespace Artify.WEB.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly HttpClient _httpClient;
        public ArtworkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ArtworkDto>> GetArtworks()
        {
            try
            {
                var artworks = await _httpClient.GetFromJsonAsync<IEnumerable<ArtworkDto>>("api/artworks");
                return artworks;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
