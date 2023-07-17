using Artify.DAL;
using Artify.Repositories.Contracts;

namespace Artify.Repository.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IArtworkRepository> _artworkRepository;
        private readonly Lazy<IAuthorRepository> _authorRepository;

        public RepositoryManager (RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _artworkRepository = new Lazy<IArtworkRepository>( () => 
                new ArtworkRepository(repositoryContext));
            _authorRepository = new Lazy<IAuthorRepository>(() => 
                new AuthorRepository(repositoryContext));
        }

        public IArtworkRepository Artwork => _artworkRepository.Value;
        public IAuthorRepository Author => _authorRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
    }
}
