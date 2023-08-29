using Artify.Entities.Models;

namespace Artify.Repositories.Contracts
{
    public interface IAuthorProfileRepository
    {
        Task<AuthorProfile> GetByIdAsync(Guid authorId, bool trackChanges);
        Task CreateDefault(Author author);
        void Update(AuthorProfile authorProfile);
    }
}
