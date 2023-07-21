using Artify.Entities.DTO;
using Artify.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Artify.Presentation.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthorController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _service.AuthorService.GetAll(trackChanges:false);

            return Ok(authors);
        }

        [HttpGet("{authorId:guid}", Name = "AuthorById")]
        public IActionResult GetAuthorById(Guid authorId)
        {
            var author = _service.AuthorService.Get(authorId, trackChanges: false);

            return Ok(author);
        }

        [HttpGet("{authorId}/artworks")]
        public IActionResult GetArtworksForAuthor(Guid authorId)
        {
            var artworks = _service.ArtworkService.GetAllForAuthor(authorId, false);

            return Ok(artworks);
        }

        [HttpDelete("{authorId:guid}")]
        public IActionResult DeleteAuthor(Guid authorId)
        {
            _service.AuthorService.Delete(authorId, trackChanges:false);

            return NoContent();
        }

        [HttpPost]
        public IActionResult CreateAuthor(AuthorForCreationDto author)
        {
           var createdAuthor =  _service.AuthorService.Create(author);

            return CreatedAtRoute("AuthorById", new { authorId = createdAuthor.Id }, createdAuthor);
        }
    }
}
