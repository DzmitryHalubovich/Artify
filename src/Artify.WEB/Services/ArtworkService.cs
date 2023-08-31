using Artify.WEB.Models;
using Artify.WEB.Services.Interfaces;
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
        private readonly AuthenticationStateProvider _authProvider;
        //New

        public ArtworkService(HttpClient client, AuthenticationStateProvider authProvider)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authProvider=authProvider;
        }

        public async Task CreateArtwork(ArtworkCreateModel artwork)
        {
            var authState = await _authProvider.GetAuthenticationStateAsync();
            var userId = authState.User.FindFirst("AuthorId")!.Value;

            var postResult = await _client.PostAsJsonAsync($"api/authors/{userId}/artworks", artwork);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task DeleteArtwork(Guid authorId, Guid artworkId)
        {
            var deleteResult = await _client.DeleteAsync($"api/authors/{authorId}/artworks/{artworkId}");
        }

        public async Task<ArtworkModel> GetArtwork(Guid artworkId)
        {
            var product = await _client.GetFromJsonAsync<ArtworkModel>($"/api/artworks/{artworkId}");
            return product;
        }

        public async Task<IEnumerable<ArtworkModel>> GetArtworks()
        {
            var response = await _client.GetAsync("api/artworks");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var artworks = JsonSerializer.Deserialize<List<ArtworkModel>>(content, _options);
            return artworks;
        }

        public async Task<IEnumerable<ArtworkModel>> GetArtworksForAuthor(Guid authorId)
        {
            var response = await _client.GetAsync($"api/{authorId}/artworks");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var artworks = JsonSerializer.Deserialize<List<ArtworkModel>>(content, _options);
            return artworks;
        }
        public async Task<AuthorModel> GetAuthor(Guid authorId)
        {
            var author = await _client.GetFromJsonAsync<AuthorModel>($"/api/authors/{authorId}");
            return author;
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
