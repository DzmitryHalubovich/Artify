using Artify.Entities.DTO;
using Artify.Entities.Models;
using Artify.Repository;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Test.Helpers;
using TestSupport.EfHelpers;

namespace Artify.API.Tests.IntegrationTests
{
    public class AuthorControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private string connectionString;
        IConfigurationRoot configuration;

        public AuthorControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
        }

        [Fact]
        public async void AuthorController_GetAuthors_OkStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("api/authors");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async void AuthorController_Create_CreateNewAuthor()
        {
            //Arrange
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(host =>
                {
                    host.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<RepositoryContext>));
                        services.Remove(descriptor);

                        services.AddDbContext<RepositoryContext>(options =>
                        {
                            options.UseInMemoryDatabase("InMemoryDB");
                        });
                    });
                });
            var httpClient = appFactory.CreateClient();

            var newAuthor = new AuthorForCreationDto("Thomas");

            var json = JsonSerializer.Serialize(newAuthor);

            var content = new StringContent(
                json,
                System.Text.Encoding.UTF8,
                "application/json");

            // Act
            using var response = await httpClient.PostAsync(
                "api/authors", content);

            var scope = appFactory.Services.GetService<IServiceScopeFactory>()!.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<RepositoryContext>();

            //Assert
            Assert.NotNull(dbContext);
            Assert.Single(dbContext!.Authors);
        }

        [Fact]
        public async Task AuthorController_GetAuthorById_GetAuthorSuccess()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<RepositoryContext>();

            connectionString = configuration.GetConnectionString("TestSqlConnection");

            builder.UseSqlServer(connectionString);
            
            using var context = new RepositoryContext(builder.Options);

            await context.Database.EnsureCreatedAsync();
            context.Database.EnsureClean();

            var newAuthors = new List<Author>
            {
                new Author
                {
                    Id = new Guid("195E720F-9927-4031-9979-163F4BAC1ECB"),
                    Name = "Thomas Anderson",
                    StoragePath = "TestPath/Thomas Anderson"
                },
                new Author
                {
                    Id = new Guid("4ADD71A9-16DC-4F70-81D8-59EC711AA05F"),
                    Name = "Heisenberg",
                    StoragePath = "TestPath/Heisenberg"
                },
                new Author
                {
                    Id = new Guid("3733AC7A-88F1-4386-8E63-8CF31F8E2F01"),
                    Name = "Heisenberg",
                    StoragePath = "TestPath/Heisenberg"
                }
            };

            var count = context.AddRangeAsync(newAuthors);
            await context.SaveChangesAsync();

            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(host =>
                {
                    host.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<RepositoryContext>));
                        services.Remove(descriptor);

                        services.AddDbContext<RepositoryContext>(options =>
                        {
                            options.UseSqlServer(connectionString);
                        });
                    });
                });

            var httpClient = appFactory.CreateClient();

            // Act
            var response = await httpClient.GetFromJsonAsync<AuthorDto>(
                "api/authors/3733AC7A-88F1-4386-8E63-8CF31F8E2F01");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(new Guid("3733AC7A-88F1-4386-8E63-8CF31F8E2F01"), response.Id);
            Assert.Equal("Heisenberg", response.Name);
            Assert.Equal("TestPath/Heisenberg", response.StoragePath);

            appFactory.Dispose();
            httpClient.Dispose();

            await context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task AuthorController_DeleteAuthor_DeleteAuthorSuccess()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<RepositoryContext>();

            connectionString = configuration.GetConnectionString("DeleteTestSqlConnection");

            builder.UseSqlServer(connectionString);

            using var context = new RepositoryContext(builder.Options);

            await context.Database.EnsureCreatedAsync();
            context.Database.EnsureClean();

            var newAuthors = new List<Author>
            {
                new Author
                {
                    Id = new Guid("195E720F-9927-4031-9979-163F4BAC1ECB"),
                    Name = "Thomas Anderson",
                    StoragePath = "TestPath/Thomas Anderson"
                },
                new Author
                {
                    Id = new Guid("4ADD71A9-16DC-4F70-81D8-59EC711AA05F"),
                    Name = "Heisenberg",
                    StoragePath = "TestPath/Heisenberg"
                },
                new Author
                {
                    Id = new Guid("3733AC7A-88F1-4386-8E63-8CF31F8E2F01"),
                    Name = "Heisenberg",
                    StoragePath = "TestPath/Heisenberg"
                }
            };

            var count = context.AddRangeAsync(newAuthors);
            await context.SaveChangesAsync();

            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(host =>
                {
                    host.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<RepositoryContext>));
                        services.Remove(descriptor);

                        services.AddDbContext<RepositoryContext>(options =>
                        {
                            options.UseSqlServer(connectionString);
                        });
                    });
                });

            var httpClient = appFactory.CreateClient();

            // Act
            var deleteAction = await httpClient.DeleteAsync(
                "api/authors/3733AC7A-88F1-4386-8E63-8CF31F8E2F01");

            //Assert
            Assert.Equal(2,context.Authors.Count());
            Assert.Equal(null,context.Authors.FirstOrDefault(x=>x.Id == new Guid("3733AC7A-88F1-4386-8E63-8CF31F8E2F01")));

            appFactory.Dispose();
            httpClient.Dispose();

            await context.Database.EnsureDeletedAsync();
        }
    }
}