﻿using Artify.Services.Contracts;
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

        [HttpGet("{authorId}/artworks")]
        public IActionResult GetArtworksForAuthor(Guid authorId)
        {
            var artworks = _service.ArtworkService.GetAllForAuthor(authorId, false);

            return Ok(artworks);
        }
    }
}
