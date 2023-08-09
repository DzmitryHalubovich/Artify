using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artify.Entities.DTO.Authorization
{
    public record TokenDto(string Token, string RefreshToken);
}
