using Artify.Entities.Models;

namespace Artify.Contracts.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll(bool trackChanges);
    }
}
