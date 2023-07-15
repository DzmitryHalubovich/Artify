using Artify.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artify.BusinessLogic.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArtworkService> _artworkService;
        private readonly Lazy<IAuthorService> _authorService;

        public IArtworkService ArtworkService => throw new NotImplementedException();

        public IAuthorService AuthorService => throw new NotImplementedException();
    }
}
