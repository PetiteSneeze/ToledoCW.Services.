using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ToledoCW.Services.Infraestructure.Repositorios;

public class RepositorioBase<T> : IRepositorioBase<T> where T : class
{
    protected readonly DbContext DbContext;
    protected readonly DbSet<T> DbSet;

    public RepositorioBase(ToledoCWContext dbContext)
    {
        DbContext = dbContext;
        DbSet = DbContext.Set<T>();
    }

    public async Task<T> Create(T entity)
    {
        await DbSet.AddAsync(entity);
        
        return Commit() ? entity : throw new Exception("Erro ao salvar entidade " + nameof(T));
    }
    
    public async Task<T?> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        return await Task.FromResult(GetListQuery(predicate, include, orderBy).FirstOrDefault());
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        return await Task.FromResult(GetListQuery(predicate, include, orderBy).ToList());
    }

    public Task<T> Update(T entity)
    {
        if (DbContext.ChangeTracker.Entries().FirstOrDefault(x => x.Entity.Equals(entity)) != null)
            DbContext.Entry(entity).CurrentValues.SetValues(entity);
        else
            DbContext.Entry(entity).State = EntityState.Modified;

        DbContext.SaveChanges();
        
        return Task.FromResult(entity);
    }

    public async Task<T> Delete(T entity)
    {
        DbContext.Entry(entity).State = EntityState.Deleted;
        return await Task.FromResult(entity);
    }

    public bool Commit()
    {
        DbContext.SaveChanges();
        return true;
    }
    
    protected IQueryable<T> GetListQuery(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        var _query = DbSet.AsQueryable();

        if (include is not null)
            _query = include(_query);

        if (predicate is not null)
            _query = _query.Where(predicate);

        if (orderBy is not null)
            _query = orderBy(_query);

        return _query;
    }
}