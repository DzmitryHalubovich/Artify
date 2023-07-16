using Artify.Repositories.Contracts;
using Artify.Services.Contracts;
using AutoMapper;

namespace Artify.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArtworkService> _artworkService;
        private readonly Lazy<IAuthorService> _authorService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _artworkService = new Lazy<IArtworkService>(() => 
                    new ArtworkService(repositoryManager, mapper));
            _authorService = new Lazy<IAuthorService>(() => 
                    new AuthorService(repositoryManager, mapper));
        }
        public IArtworkService ArtworkService => _artworkService.Value;

        public IAuthorService AuthorService => _authorService.Value;
    }
}
