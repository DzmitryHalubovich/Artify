using Artify.WEB.Models;

namespace Artify.WEB.Services
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
    }
}

