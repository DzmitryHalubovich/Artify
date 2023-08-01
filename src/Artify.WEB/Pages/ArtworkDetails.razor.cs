using Artify.Entities.Models;
using Artify.WEB.Models;
using Artify.WEB.Services;
using Microsoft.AspNetCore.Components;

namespace Artify.WEB.Pages
{
    public partial class ArtworkDetails
    {
        [Parameter]
        public Guid Id { get; set; }

        public ArtworkDto artwork = new ArtworkDto();

        [Inject]
        public IArtworkService ArtworkService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            artwork = await ArtworkService.GetArtwork(Id);
        }
    }
}
