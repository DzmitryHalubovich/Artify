using Artify.API.Filters;
using Artify.Entities.DTO;
using Artify.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artify.Presentation.Controllers
{
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthorController(IServiceManager service) => _service = service;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _service.AuthorService.GetAllAsync(trackChanges:false);

            return Ok(authors);
        }

        [HttpGet("{authorId:guid}", Name = "AuthorById")]
        public async Task<IActionResult> GetAuthorById(Guid authorId)
        {
            var author = await _service.AuthorService.GetByIdAsync(authorId, trackChanges: false);

            return Ok(author);
        }

        [HttpGet("{authorId}/artworks")]
        public async Task<IActionResult> GetArtworksForAuthor(Guid authorId)
        {
            var artworks = await _service.ArtworkService.GetAllForAuthorAsync(authorId, false);

            return Ok(artworks);
        }

        [HttpPut("{authorId:guid}/profile")]
        public async Task<IActionResult> UpdateAuthorProfile(Guid authorId, AuthorProfileUpdateDto authorProfile)
        {
            var doesAuthorExists = await _service.AuthorService.GetByIdAsync(authorId, false);

            await _service.AuthorProfileService.Update(authorId, authorProfile);

            return Ok(authorProfile);
        }

        [HttpDelete("{authorId:guid}")]
        public async Task<IActionResult> DeleteAuthor(Guid authorId)
        {
            await _service.AuthorService.DeleteAsync(authorId, trackChanges:false);

            return NoContent();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAuthor(AuthorForCreationDto author)
        {
            var createdAuthor = await  _service.AuthorService.CreateAsync(author);

            return CreatedAtRoute("AuthorById", new { authorId = createdAuthor.Id }, createdAuthor);
        }
    }
}
