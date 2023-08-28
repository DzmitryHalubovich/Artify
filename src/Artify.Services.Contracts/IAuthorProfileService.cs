using Artify.Entities.DTO;

namespace Artify.Services.Contracts
{
    public interface IAuthorProfileService
    {
        public Task Update(Guid authorId, AuthorProfileUpdateDto authorProfile);
    }
}
