using Artify.DAL.Entities;

namespace Artify.Contracts.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors(bool trackChanges);
    }
}
