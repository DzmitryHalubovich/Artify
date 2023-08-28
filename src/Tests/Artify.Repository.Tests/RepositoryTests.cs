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
                    UserName = "TestUserName",
                    Email = "testmail@gmail.com",

                    Profile = new AuthorProfile() 
                    {
                        Name = "Test",
                        City = "TestCity",
                        Profession = "TestProfession",
                        Country = "TestCountry"
                    }
                };

                _repository.Author.Create(newAuthor);

                await _repository.SaveAsync();

                var hasCreated = await _repository.Author.GetByIdAsync(newAuthor.Id, true);

                Assert.NotNull(hasCreated);
                Assert.Equal("TestUserName", hasCreated.UserName);
            }
        }
    }
}