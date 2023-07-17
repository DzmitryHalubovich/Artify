using Artify.Entities.DTO;
using Artify.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Artify.Presentation.Controllers
{
    [Route("api/artworks")]
    [ApiController]
    public class ArtworkController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILogger _logger;

        public ArtworkController(IServiceManager service, ILoggerFactory logger)
        {
            _service = service;
            _logger = logger.CreateLogger<ArtworkController>();
        }

        [HttpGet]
        public IActionResult GetArtworks()
        {
            var artworks = _service.ArtworkService.GetAll(trackChanges:false);

            return Ok(artworks);
        }

        [HttpGet("{artworkId:guid}")]
        public IActionResult GetArtwork(Guid artworkId)
        {
            var artwork = _service.ArtworkService.Get(artworkId, trackChanges: false);

            return Ok(artwork);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetArtworkForAuthor(Guid authorId, Guid artworkId)
        {
            var artwork = _service.ArtworkService.GetArtwork(authorId, artworkId, trackChanges:false);
            return Ok(artwork);
        }
    }
}
