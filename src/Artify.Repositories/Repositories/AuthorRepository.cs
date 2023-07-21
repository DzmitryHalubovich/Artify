using Artify.Entities.Models;
using Artify.Repositories.Contracts;

namespace Artify.Repository.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void Create(Author author) => CreateEntity(author);

        public void Delete(Author author) => DeleteEntity(author);


        public Author Get(Guid authorId, bool trackChanges) =>
            FindByCondition(a => a.Id.Equals(authorId), trackChanges)
                .SingleOrDefault();
            


        public IEnumerable<Author> GetAllAuthors(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c=>c.Name)
                .ToList();

        public Author GetByName(string authorName) =>
            FindByCondition(a => a.Name.Equals(authorName), false)
                .SingleOrDefault();


    }
}
