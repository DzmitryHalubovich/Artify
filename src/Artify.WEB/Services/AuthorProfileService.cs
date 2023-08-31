using Artify.WEB.Models;
using Artify.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace Artify.WEB.Services
{
    public class AuthorProfileService : IAuthorProfileService
    {
        private readonly HttpClient _client;
        private readonly AuthenticationStateProvider _authProvider;

        public AuthorProfileService(HttpClient client, AuthenticationStateProvider authProvider)
        {
            _client=client;
            _authProvider=authProvider;
        }

        public async Task UpdateAsync(AuthorProfileUpdateModel authorProfile)
        {
            var authState = await _authProvider.GetAuthenticationStateAsync();
            var userId = authState.User.FindFirst("AuthorId")!.Value;

            var response = await _client.PutAsJsonAsync($"api/authors/{new Guid(userId)}/profile", authorProfile);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
