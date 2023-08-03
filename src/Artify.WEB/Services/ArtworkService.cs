using Artify.Entities.Models;
using Artify.WEB.AuthProviders;
using Artify.WEB.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Artify.WEB.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationState _anonymous;
        public ArtworkService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
           
        }

        public async Task CreateArtwork(Artwork artwork)
        {
            var content = JsonSerializer.Serialize(artwork);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var postResult = await _client.PostAsync($"api/authors/{artwork.AuthorId}/artworks", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task<ArtworkDto> GetArtwork(Guid artworkId)
        {
            var product = await _client.GetFromJsonAsync<ArtworkDto>($"/api/artworks/{artworkId}");
            return product;
        }

        public async Task<IEnumerable<ArtworkDto>> GetArtworks()
        {
            var response = await _client.GetAsync("api/artworks");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var artworks = JsonSerializer.Deserialize<List<ArtworkDto>>(content, _options);
            return artworks;
        }

        public async Task<string> UploadProductImage(MultipartFormDataContent content)
        {
            var postResult = await _client.PostAsync("api/upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine("https://localhost:7062", postContent);
                return imgUrl;
            }
        }
    }
}
