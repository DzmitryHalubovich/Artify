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
        public IActionResult GetArtworks()
        {
            var artworks = _service.ArtworkService.GetAll(trackChanges: false);

            return Ok(artworks);
        }

        [HttpGet("artworks/{artworkId:guid}", Name = "ArtworkById")]
        public IActionResult GetArtwork(Guid artworkId)
        {
            var artwork = _service.ArtworkService.Get(artworkId, trackChanges: false);

            return Ok(artwork);
        }

        [HttpPost("authors/{authorId:guid}/artworks")]
        public async Task<IActionResult> CreateArtwork(Guid authorId, [FromForm] ArtworkForCreationDto artwork)
        {
            if (artwork == null)
                return BadRequest("ArtworkForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdArtwork =
                await _service.ArtworkService.CreateForAuthor(authorId, artwork, trackChanges: false);

            return CreatedAtRoute("ArtworkById", new { artworkId = createdArtwork.Id },
                createdArtwork);
        }

        [HttpDelete("authors/{authorId:guid}/artworks/{artworkId:guid}")]
        public IActionResult DeleteArtwork(Guid authorId, Guid artworkId)
        {
            _service.ArtworkService.Delete(authorId, artworkId, trackChanges: false);

            return NoContent();
        }
    }
}
