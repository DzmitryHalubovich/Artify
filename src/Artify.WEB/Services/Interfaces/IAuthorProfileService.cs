using Artify.WEB.Models;

namespace Artify.WEB.Services.Interfaces
{
    public interface IAuthorProfileService
    {
        public Task UpdateAsync(AuthorProfileUpdateModel authorProfile);
    }
}
