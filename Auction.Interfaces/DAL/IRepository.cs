

using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Auction.Interfaces.DAL;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetFirstOrDefault(
        Expression<Func<TEntity,bool>> filter,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? sorts = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool disableTracking = false
        );

    Task<TEntity> Create(TEntity entity);

    Task<TEntity> Update(TEntity entity);
    Task<TEntity> Delete(TEntity entity);
}


