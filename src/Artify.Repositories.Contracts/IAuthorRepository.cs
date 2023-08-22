using Artify.Entities.DTO;
using Artify.Entities.Models;

namespace Artify.Repositories.Contracts
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
        Task<Author> GetByIdAsync(Guid authorId, bool trackChanges);
        Task<AuthorDto> GetShortAuthor(Guid authorId);
        void Delete(Author author);
        void Create(Author author);
    }
}
