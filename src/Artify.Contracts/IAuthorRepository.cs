using Artify.Entities.Models;

namespace Artify.Repositories.Contracts
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors(bool trackChanges);
        Author Get(Guid authorId, bool trackChanges);
        Author GetByName(string authorName);
    }
}
