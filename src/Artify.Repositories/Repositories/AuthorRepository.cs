using Artify.Entities.Models;
using Artify.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Artify.Repository.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void Create(Author author) => CreateEntity(author);

        public void Delete(Author author) => DeleteEntity(author);


        public async Task<Author> GetByIdAsync(Guid authorId, bool trackChanges) => 
            await FindByCondition(a => a.Id.Equals(authorId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges) => 
            await FindAll(trackChanges)
                .OrderBy(c=>c.UserName)
                .ToListAsync();

        public async Task<Author> GetByName(string authorName) => 
            await FindByCondition(a => a.UserName.Equals(authorName), false)
                .SingleOrDefaultAsync();

    }
}
