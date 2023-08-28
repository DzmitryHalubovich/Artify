using Artify.Entities.DTO;
using Artify.Entities.Models;
using Artify.Repositories.Contracts;
using Artify.Services.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artify.Services
{
    public class AuthorProfileService : IAuthorProfileService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AuthorProfileService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager=repositoryManager;
            _mapper=mapper;
        }

        public async Task Update(Guid authorId, AuthorProfileUpdateDto authorProfile)
        {
            var newAuthorProfile = _mapper.Map<AuthorProfile>(authorProfile);

            newAuthorProfile.AuthorId = authorId;

            _repositoryManager.AuthorProfile.Update(newAuthorProfile);
            await _repositoryManager.SaveAsync();
        }

    }
}
