using Artify.WEB.Models;
using Microsoft.AspNetCore.Components;

namespace Artify.WEB.Components
{
    public partial class ArtworkTable
    {
        [Parameter]
        public IEnumerable<ArtworkDto> Artworks { get; set; }
    }
}
