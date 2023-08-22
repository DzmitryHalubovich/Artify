using Artify.DAL;
using Artify.Entities.DTO;
using Artify.Entities.Models;
using Artify.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq;
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

        public void CreateEntity(T entity) => _repositoryContext.Set<T>().Add(entity);
        public void UpdateEntity(T entity) => _repositoryContext.Set<T>().Update(entity);
        public void DeleteEntity(T entity) => _repositoryContext.Set<T>().Remove(entity);    }
}
