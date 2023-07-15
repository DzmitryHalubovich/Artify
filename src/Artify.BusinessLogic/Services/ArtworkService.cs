using Artify.Contracts.Repositories;
using Artify.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artify.BusinessLogic.Services
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
