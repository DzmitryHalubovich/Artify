using Artify.WEB.Models;
using Artify.WEB.Services;
using Microsoft.AspNetCore.Components;

namespace Artify.WEB.Pages
{
    public partial class Artworks
    {
        [Inject]
        public IArtworkService ArtworkService { get; set; }

        public IEnumerable<ArtworkDto> ArtworksList { get; set; } = new List<ArtworkDto>();

        protected override async Task OnInitializedAsync()
        {
            ArtworksList = await ArtworkService.GetArtworks();

            foreach (var artworkDto in ArtworksList)
            {
                Console.WriteLine(artworkDto);
            }
        }
    }
}
