using Artify.Entities.DTO;
using Artify.WEB.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Artify.WEB.Pages
{
    public class ArtworksBase : ComponentBase
    {
        [Inject]
        public IArtworkService ArtworkService { get; set; }

        public IEnumerable<ArtworkDto> Artworks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Artworks = await ArtworkService.GetArtworks();
        }

    }
}
