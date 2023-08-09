using Microsoft.AspNetCore.Identity;

namespace Artify.Entities.DTO.Authorization
{
    public class RegistrationResponseDto
    {
        public IdentityResult Result { get; set; }
        public UserForAuthenticationDto User { get; set; }
    }
}
