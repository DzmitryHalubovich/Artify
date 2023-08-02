using Artify.Entities.Models;
using Artify.Repositories.Contracts;
using Artify.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Artify.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArtworkService> _artworkService;
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, 
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _artworkService = new Lazy<IArtworkService>(() =>
                    new ArtworkService(repositoryManager, mapper, configuration));
            _authorService = new Lazy<IAuthorService>(() =>
                    new AuthorService(repositoryManager, mapper, configuration));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                    new AuthenticationService(mapper, userManager, configuration));
        }
        public IArtworkService ArtworkService => _artworkService.Value;

        public IAuthorService AuthorService => _authorService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
