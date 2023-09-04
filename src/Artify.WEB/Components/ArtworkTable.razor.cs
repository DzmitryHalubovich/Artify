using Artify.WEB.Models.Artwork;
using Microsoft.AspNetCore.Components;

namespace Artify.WEB.Components
{
    public partial class ArtworkTable
    {
        [Parameter]
        public IEnumerable<ArtworkDetailsModel> Artworks { get; set; }
    }
}
