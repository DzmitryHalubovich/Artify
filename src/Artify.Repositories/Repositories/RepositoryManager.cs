using Artify.Repositories.Contracts;
using Artify.Repositories.Repositories;

namespace Artify.Repository.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IArtworkRepository> _artworkRepository;
        private readonly Lazy<IAuthorProfileRepository> _authorProfileRepository;
        private readonly Lazy<IAuthorRepository> _authorRepository;

        public RepositoryManager (RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _artworkRepository = new Lazy<IArtworkRepository>( () => 
                new ArtworkRepository(repositoryContext));
            _authorRepository = new Lazy<IAuthorRepository>(() => 
                new AuthorRepository(repositoryContext));
            _authorProfileRepository = new Lazy<IAuthorProfileRepository>(() =>
                new AuthorProfileRepository(repositoryContext));
        }

        public IArtworkRepository Artwork => _artworkRepository.Value;
        public IAuthorRepository Author => _authorRepository.Value;
        public IAuthorProfileRepository AuthorProfile => _authorProfileRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
