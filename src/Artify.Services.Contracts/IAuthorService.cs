
using Artify.Entities.DTO;

namespace Artify.Services.Contracts
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAll(bool trackChanges);
    }
}
