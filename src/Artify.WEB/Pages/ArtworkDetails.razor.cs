using Artify.WEB.Models.Artwork;

namespace Artify.WEB.Pages
{
    public partial class ArtworkDetails
    {
        [Parameter]
        public Guid ArtworkId { get; set; }

        public ArtworkDetailsModel artwork = new ArtworkDetailsModel();

        [Inject]
        public IArtworkService ArtworkService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            artwork = await ArtworkService.GetArtwork(ArtworkId);
        }
    }
}
