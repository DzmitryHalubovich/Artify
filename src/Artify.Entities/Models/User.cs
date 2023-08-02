using Microsoft.AspNetCore.Identity;

namespace Artify.Entities.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
