using Artify.WEB.Models.Artwork;
using Artify.WEB.Services;
using Artify.WEB.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Artify.WEB.Pages
{
    public partial class AuthorPersonalCollection : IDisposable
    {
        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IArtworkService ArtworkService { get; set; }

        [Inject]
        public AuthenticationStateProvider _authProvider { get; set; }

        public IEnumerable<ArtworkDetailsModel> ArtworksList { get; set; } = new List<ArtworkDetailsModel>();

        public AuthorModel Author { get; set; } = new AuthorModel();

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            
            var user = await _authProvider.GetAuthenticationStateAsync();
            var authorId = Guid.Parse(user.User.FindFirst("AuthorId")!.Value.ToString());

            ArtworksList = await ArtworkService.GetArtworksForAuthor(authorId);
            Author = await ArtworkService.GetAuthor(authorId);

            foreach (var artworkDto in ArtworksList)
            {
                Console.WriteLine(artworkDto);
            }
        }

        public async Task DeleteArtwork(Guid artworkId)
        {
            await ArtworkService.DeleteArtwork(Author.Id, artworkId);
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }

}
