using Artify.Entities.DTO.Artwork;
using Artify.Entities.Models;
using Artify.Presentation.Controllers;
using Artify.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Artify.Presentation.Tests
{
    public class ArtworkControllerTests
    {
        private readonly Mock<ILoggerFactory> _mockLogger;
        private readonly Mock<IServiceManager> _mockServices;
        private readonly ArtworkController _controller;

        public ArtworkControllerTests()
        {
            _mockLogger = new Mock<ILoggerFactory>();
            _mockServices = new Mock<IServiceManager>();
            _controller = new ArtworkController(_mockServices.Object, _mockLogger.Object);
        }

        #region Check validation
        [Theory]
        [MemberData(nameof(GetArtworks))]
        public void ArtworkCreate_TryCreateInvalidArtwork_FailValidation(Guid authorId, ArtworkForCreationDto artwork) =>
            Assert.True(_controller.CreateArtwork(authorId, artwork).IsFaulted);

        [Theory]
        [MemberData(nameof(GetArtworks))]
        public void ArtworkCreate_TryCreateInvalidArtwork_ThrowArgumentException(Guid authorId, ArtworkForCreationDto artwork) =>
            Assert.ThrowsAsync<ArgumentException>(() =>  _controller.CreateArtwork(authorId, artwork));
        #endregion

        [Fact]
        public async Task GetArtworks_GetAllArtworks_ReturnExactNumberOfArtworks()
        {
            _mockServices.Setup(serv => serv.ArtworkService.GetAllAsync(false))
                .ReturnsAsync(new List<ArtworkDto>() 
                { 
                    new ArtworkDto() { Title = "TestTitle1", ImageUrl = "TestUrl" }, 
                    new ArtworkDto() { Title = "TestTitle2", ImageUrl = "TestUrl2" } 
                });

            var result = await _controller.GetArtworks();

            var actionResult = Assert.IsType<OkObjectResult>(result);
            var artworks = Assert.IsType<List<ArtworkDto>>(actionResult.Value);
            Assert.Equal(2, artworks.Count);
        }

        public static IEnumerable<object[]> GetArtworks()
        {
            yield return new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new ArtworkForCreationDto { } };
            yield return new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new ArtworkForCreationDto { Title ="Test Title", Description = "Test description", ImageUrl = "" } };
            yield return new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new ArtworkForCreationDto { Title ="", ImageUrl = "TestUrl" } };
            yield return new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new ArtworkForCreationDto { Title ="", Description = "", ImageUrl = "" } };
        }
    }
}
