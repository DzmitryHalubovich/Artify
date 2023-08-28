using Artify.Entities.Models;

namespace Artify.Repositories.Contracts
{
    public interface IAuthorProfileRepository
    {
        Task CreateDefault(Author author);
        void Update(AuthorProfile authorProfile);
    }
}
