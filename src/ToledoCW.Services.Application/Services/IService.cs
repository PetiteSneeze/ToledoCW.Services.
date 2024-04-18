using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace ToledoCW.Services.Services;

public interface IService
{
    
}

public interface IService<TEntity> where TEntity : class
{

    // public Task<TEntity> Save(TEntity obj, bool forced = false);

    public Task<TEntity> Delete(TEntity obj, bool forced = false);

    // public Task<TEntity> FindById(long id,
    //     Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
    //     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

    public Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

    public Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

    // public Task<TEntity> SaveTransaction(TEntity obj);

    public Task<TEntity> DeleteTransaction(TEntity obj);

}