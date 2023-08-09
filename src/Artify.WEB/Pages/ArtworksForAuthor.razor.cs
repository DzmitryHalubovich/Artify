﻿using Artify.WEB.Models;
using Artify.WEB.Services;
using Microsoft.AspNetCore.Components;

namespace Artify.WEB.Pages
{
    public partial class ArtworksForAuthor : IDisposable
    {

        [Parameter]
        public Guid AuthorId { get; set; }
          
        [Inject]
        public IArtworkService ArtworkService { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        public IEnumerable<ArtworkModel> ArtworksList { get; set; } = new List<ArtworkModel>();
        public AuthorModel Author { get; set; } = new AuthorModel();

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            ArtworksList = await ArtworkService.GetArtworksForAuthor(AuthorId);
            Author = await ArtworkService.GetAuthor(AuthorId);

            foreach (var artworkDto in ArtworksList)
            {
                Console.WriteLine(artworkDto);
            }
        }

        public void Dispose() => Interceptor.DisposeEvent();
    }
}
