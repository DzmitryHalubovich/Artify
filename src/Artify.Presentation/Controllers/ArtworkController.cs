using Artify.API.Filters;
using Artify.Entities.DTO.Artwork;
using Artify.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Artify.Presentation.Controllers
{
    [ApiController]
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
        [Authorize]
        public async Task<IActionResult> GetArtworks()
        {
            var artworks = await _service.ArtworkService.GetAllAsync(trackChanges: false);

            return Ok(artworks);
        }

        [HttpGet("{authorId}/artworks")]
        public async Task<IActionResult> GetArtworksForAuthor(Guid authorId)
        {
            var artworks = await _service.ArtworkService.GetAllForAuthorAsync(authorId, false);

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
        public async Task<IActionResult> CreateArtwork(Guid authorId, [FromBody] ArtworkForCreationDto artwork)
        {
            var createdArtwork =
                await _service.ArtworkService.CreateForAuthorAsync(authorId, artwork, trackChanges: false);

            return CreatedAtRoute("ArtworkById", new { artworkId = createdArtwork.ArtworkId },
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
