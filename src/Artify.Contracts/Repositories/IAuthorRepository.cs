using Artify.Entities.Models;

namespace Artify.Contracts.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors(bool trackChanges);
    }
}
