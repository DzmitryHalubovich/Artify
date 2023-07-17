
using Artify.Entities.DTO;

namespace Artify.Services.Contracts
{
    public interface IAuthorService
    {
        public IEnumerable<AuthorDto> GetAll(bool trackChanges);
    }
}
