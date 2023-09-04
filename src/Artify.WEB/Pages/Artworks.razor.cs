using Artify.WEB.Models.Artwork;
using Artify.WEB.Services;

namespace Artify.WEB.Pages
{
    public partial class Artworks : IDisposable
    {
        [Inject]
        public IArtworkService ArtworkService { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        public IEnumerable<ArtworkDetailsModel> ArtworksList { get; set; } = new List<ArtworkDetailsModel>();

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
