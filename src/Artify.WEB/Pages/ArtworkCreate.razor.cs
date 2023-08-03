using Artify.Entities.Models;
using Artify.WEB.AuthProviders;
using Artify.WEB.Services;
using Artify.WEB.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;

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
            var authState = await AuthenticationStateProvider
           .GetAuthenticationStateAsync();
            var user = authState.User;
            _artwork.AuthorId = new Guid(user.FindFirst("AuthorId").Value);
            await ArtworkService.CreateArtwork(_artwork);
            _notification.Show();
        }

        private void AssignImageUrl(string imgUrl) => _artwork.ImageUrl = imgUrl;
    }
}
