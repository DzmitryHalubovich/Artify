using Artify.WEB.Models;
using Artify.WEB.Services;
using Artify.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Artify.WEB.Pages
{
    public partial class Artworks : IDisposable
    {
        [Inject]
        public IArtworkService ArtworkService { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        public IEnumerable<ArtworkModel> ArtworksList { get; set; } = new List<ArtworkModel>();

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            ArtworksList = await ArtworkService.GetArtworks();

            foreach (var artworkDto in ArtworksList)
            {
                Console.WriteLine(artworkDto);
            }
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
