using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ToledoCW.Services.Infraestructure.Repositorios
{
    public interface IRepositorioBase<T> where T : class
    {
        public Task<T> Create(T entity);

        public Task<T?> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        public Task<T> Update(T entity);

        public  Task<T> Delete(T entity);

        public bool Commit();
    }
}