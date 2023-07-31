using Artify.API.Filters;
using Artify.Entities.DTO;
using Artify.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Artify.Presentation.Controllers
{
    [Route("api")]
    public class ArtworkController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILogger _logger;

        public ArtworkController(IServiceManager service, ILoggerFactory logger)
        {
            _service = service;
            _logger = logger.CreateLogger<ArtworkController>();
        }

        [HttpGet("artworks")]
        public async Task<IActionResult> GetArtworks()
        {
            var artworks = await _service.ArtworkService.GetAllAsync(trackChanges: false);

            return Ok(artworks);
        }

        [HttpGet("artworks/{artworkId:guid}", Name = "ArtworkById")]
        public async Task<IActionResult> GetArtwork(Guid artworkId)
        {
            var artwork = await _service.ArtworkService.GetByIdAsync(artworkId, trackChanges: false);

            return Ok(artwork);
        }

        [HttpPost("authors/{authorId:guid}/artworks")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateArtwork(Guid authorId, [FromForm] ArtworkForCreationDto artwork)
        {
            var createdArtwork =
                await _service.ArtworkService.CreateForAuthorAsync(authorId, artwork, trackChanges: false);

            return CreatedAtRoute("ArtworkById", new { artworkId = createdArtwork.Id },
                createdArtwork);
        }

        [HttpDelete("authors/{authorId:guid}/artworks/{artworkId:guid}")]
        public async Task<IActionResult> DeleteArtwork(Guid authorId, Guid artworkId)
        {
            await _service.ArtworkService.DeleteAsync(authorId, artworkId, trackChanges: false);

            return NoContent();
        }
    }
}
