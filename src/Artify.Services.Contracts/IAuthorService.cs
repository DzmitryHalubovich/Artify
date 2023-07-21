using Artify.Entities.DTO;

namespace Artify.Services.Contracts
{
    public interface IAuthorService
    {
        public IEnumerable<AuthorDto> GetAll(bool trackChanges);
        AuthorDto Get(Guid id, bool trackChanges);
        void Delete(Guid authorId, bool trackChanges);
        AuthorDto Create(AuthorForCreationDto author);
    }
}
