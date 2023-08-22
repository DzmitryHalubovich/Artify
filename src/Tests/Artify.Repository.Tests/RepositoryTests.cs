using Artify.Entities.Models;
using Artify.Repositories.Contracts;
using Artify.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Artify.Repository.Tests
{
    public class RepositoryTests
    {
        private IRepositoryManager _repository;
        DbContextOptionsBuilder<RepositoryContext> optionsBuilder = new();

        public RepositoryTests()
        {
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);
        }
       

        [Fact]
        public async Task Repo()
        {
            using (RepositoryContext rep = new(optionsBuilder.Options))
            {
                _repository = new RepositoryManager(rep);

                var newAuthor = new Author()
                {
                    PublicName = "TestName",
                    UserName = "TestUserName",
                };

                _repository.Author.Create(newAuthor);

                await _repository.SaveAsync();

                var hasCreated = await _repository.Author.GetByIdAsync(new Guid(newAuthor.Id), true);

                Assert.NotNull(hasCreated);
                Assert.Equal("TestName", hasCreated.PublicName);
                Assert.Equal("TestUserName", hasCreated.UserName);
            }
        }

        [Fact]
        public async Task AuthorRepository_GetShortAuthor_GetAuthor()
        {
            using (RepositoryContext rep = new(optionsBuilder.Options))
            {
                //Arrange
                _repository = new RepositoryManager(rep);

                var newAuthor = new Author()
                {
                    PublicName = "TestName",
                    UserName = "TestUserName",
                };

                _repository.Author.Create(newAuthor);
                await _repository.SaveAsync();

                //Act
                var tryGetShortAuthor = await _repository.Author.GetShortAuthor(new Guid(newAuthor.Id));

                //Assert
                Assert.NotNull(tryGetShortAuthor);
                Assert.Equal("TestName", tryGetShortAuthor.PublicName);
                Assert.Equal(newAuthor.Id, tryGetShortAuthor.Id.ToString());
            }
        }
    }
}