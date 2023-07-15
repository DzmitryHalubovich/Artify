using Artify.DAL.Entities;

namespace Artify.Contracts.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll(bool trackChanges);
    }
}
