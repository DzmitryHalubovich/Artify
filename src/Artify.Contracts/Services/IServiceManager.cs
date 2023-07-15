using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artify.Contracts.Services
{
    public interface IServiceManager
    {
        IArtworkService ArtworkService { get; }
        IAuthorService AuthorService { get; }
    }
}
