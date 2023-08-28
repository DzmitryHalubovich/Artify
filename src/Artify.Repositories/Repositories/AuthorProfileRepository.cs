using Artify.Entities.DTO;
using Artify.Entities.Models;
using Artify.Repositories.Contracts;
using Artify.Repository;
using Artify.Repository.Repositories;

namespace Artify.Repositories.Repositories
{
    public class AuthorProfileRepository : RepositoryBase<AuthorProfile>, IAuthorProfileRepository
    {
        public AuthorProfileRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task CreateDefault(Author author)
        {
            var defaultAuthorProfile = new AuthorProfile()
            {
                Author = author,
                City = "Default",
                Country = "Default",
                Name = author.UserName,
                Profession = "Author"
            };

            await CreateEntity(defaultAuthorProfile);
        }

        public void Update(AuthorProfile authorProfile) => UpdateEntity(authorProfile);

    }
}
