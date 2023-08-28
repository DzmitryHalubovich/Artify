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
        private readonly Lazy<IAuthorProfileService> _authorProfileService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, 
            IMapper mapper,
            UserManager<Author> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            IConfiguration configuration)
        {
            _artworkService = new Lazy<IArtworkService>(() =>
                    new ArtworkService(repositoryManager, mapper));
            _authorService = new Lazy<IAuthorService>(() =>
                    new AuthorService(repositoryManager, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                    new AuthenticationService(mapper, userManager, configuration, roleManager, repositoryManager));
            _authorProfileService = new Lazy<IAuthorProfileService>(() => 
                    new AuthorProfileService(repositoryManager, mapper));

        }
        public IArtworkService ArtworkService => _artworkService.Value;

        public IAuthorService AuthorService => _authorService.Value;
        public IAuthorProfileService AuthorProfileService => _authorProfileService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
