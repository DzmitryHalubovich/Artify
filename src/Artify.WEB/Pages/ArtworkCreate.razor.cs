using Artify.WEB.Models;
using Artify.WEB.Services;
using Artify.WEB.Services.Interfaces;
using Artify.WEB.Shared;
using Microsoft.AspNetCore.Components;

namespace Artify.WEB.Pages
{
    public partial class ArtworkCreate : IDisposable
    {
        private ArtworkCreateModel _artwork = new ArtworkCreateModel();

        private SuccessNotification _notification;

        [Inject]
        public IArtworkService ArtworkService { get; set; }
        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        private async Task Create()
        {
            Interceptor.RegisterEvent();

            await ArtworkService.CreateArtwork(_artwork);
            _notification.Show();
        }

        private void AssignImageUrl(string imgUrl) => _artwork.ImageUrl = imgUrl;

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
