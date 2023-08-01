using Artify.Entities.Models;
using Artify.WEB.Services;
using Artify.WEB.Shared;
using Microsoft.AspNetCore.Components;

namespace Artify.WEB.Pages
{
    public partial class ArtworkCreate
    {
        private Artwork _artwork = new Artwork();
        private SuccessNotification _notification;

        [Inject]
        public IArtworkService ArtworkService { get; set; }

        private async Task Create()
        {
            await ArtworkService.CreateArtwork(_artwork);
            _notification.Show();
        }

        private void AssignImageUrl(string imgUrl) => _artwork.ImageUrl = imgUrl;
    }
}
