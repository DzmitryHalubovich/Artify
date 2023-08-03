using Artify.Entities.Models;
using Artify.WEB.AuthProviders;
using Artify.WEB.Services;
using Artify.WEB.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;

namespace Artify.WEB.Pages
{
    public partial class ArtworkCreate : IDisposable
    {
        private Artwork _artwork = new Artwork();
        private SuccessNotification _notification;

        [Inject]
        public IArtworkService ArtworkService { get; set; }
        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        private async Task Create()
        {
            Interceptor.RegisterEvent();

            var authState = await AuthenticationStateProvider
           .GetAuthenticationStateAsync();
            var user = authState.User;
            _artwork.AuthorId = new Guid(user.FindFirst("AuthorId").Value);
            await ArtworkService.CreateArtwork(_artwork);
            _notification.Show();
        }

        private void AssignImageUrl(string imgUrl) => _artwork.ImageUrl = imgUrl;

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
