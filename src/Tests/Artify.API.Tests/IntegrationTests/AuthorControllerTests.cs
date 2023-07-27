using Artify.Presentation.Controllers;
using Artify.Repository;
using Artify.Repository.Repositories;
using Artify.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;

namespace Artify.API.Tests.IntegrationTests
{
    public class AuthorControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public AuthorControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/authors")]
        [InlineData("api/artworks")]
        public async void AuthorController_AllAuthors(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}