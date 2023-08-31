namespace Artify.WEB.Pages
{
    public partial class ArtworkDetails
    {
        [Parameter]
        public Guid ArtworkId { get; set; }

        public ArtworkModel artwork = new ArtworkModel();

        [Inject]
        public IArtworkService ArtworkService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            artwork = await ArtworkService.GetArtwork(ArtworkId);
        }
    }
}
