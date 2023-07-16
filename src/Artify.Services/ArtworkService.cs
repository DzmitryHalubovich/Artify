using Artify.Contracts.Repositories;
using Artify.Contracts.Services;

namespace Artify.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly IRepositoryManager _repository;
        public ArtworkService(IRepositoryManager repository)
        {
            _repository = repository;
        }
    }
}
