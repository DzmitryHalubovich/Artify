using Artify.Contracts.Repositories;
using Artify.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artify.BusinessLogic.Services
{
    public sealed class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        public AuthorService(IRepositoryManager repository)
        {
            _repository = repository;
        }


    }
}
