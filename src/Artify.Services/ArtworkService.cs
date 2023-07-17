using Artify.Repositories.Contracts;
using Artify.Services.Contracts;
using AutoMapper;

namespace Artify.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public ArtworkService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
