﻿using Artify.Entities.DTO;

namespace Artify.Services.Contracts
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync(bool trackChanges);
        Task<AuthorDto> GetByIdAsync(Guid id, bool trackChanges);
        Task<AuthorDto> CreateAsync(AuthorForCreationDto author);
        Task DeleteAsync(Guid authorId, bool trackChanges);
    }
}
