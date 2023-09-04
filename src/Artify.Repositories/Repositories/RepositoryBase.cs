using Artify.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Artify.Repository.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        => _repositoryContext = repositoryContext;

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
                _repositoryContext.Set<T>()
                    .AsNoTracking() :
                _repositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
            !trackChanges ?
                _repositoryContext.Set<T>()
                    .Where(expression)
                    .AsNoTracking() :
                _repositoryContext.Set<T>()
                    .Where(expression);

        public async Task CreateEntity(T entity) => await _repositoryContext.Set<T>().AddAsync(entity);
        public void UpdateEntity(T entity) => _repositoryContext.Set<T>().Update(entity);
        public void DeleteEntity(T entity) => _repositoryContext.Set<T>().Remove(entity);    }
}
