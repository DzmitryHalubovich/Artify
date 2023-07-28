using Artify.Entities.DTO;
using Artify.WEB.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Artify.WEB.Pages
{
    public class ArtworkDetailsBase : ComponentBase
    {
        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        public IArtworkService ArtworkService { get; set; }

        public ArtworkDto Artwork { get; set; }

        public IEnumerable<ArtworkDto> ArtworkList { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ArtworkList = await ArtworkService.GetArtworks();
                Artwork = ArtworkList.SingleOrDefault(x=>x.Id == Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
