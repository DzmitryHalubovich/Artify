using Artify.Contracts.Repositories;
using Artify.Contracts.Services;

namespace Artify.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArtworkService> _artworkService;
        private readonly Lazy<IAuthorService> _authorService;


        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _artworkService = new Lazy<IArtworkService>(() => new ArtworkService(repositoryManager));
            _authorService = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager));
        }
        public IArtworkService ArtworkService => _artworkService.Value;

        public IAuthorService AuthorService => _authorService.Value;
    }
}
