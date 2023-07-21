using Artify.Repositories.Contracts;
using Artify.Services.Contracts;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Artify.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArtworkService> _artworkService;
        private readonly Lazy<IAuthorService> _authorService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IConfiguration configuration)
        {
            _artworkService = new Lazy<IArtworkService>(() => 
                    new ArtworkService(repositoryManager, mapper, configuration));
            _authorService = new Lazy<IAuthorService>(() => 
                    new AuthorService(repositoryManager, mapper, configuration));
        }
        public IArtworkService ArtworkService => _artworkService.Value;

        public IAuthorService AuthorService => _authorService.Value;
    }
}
