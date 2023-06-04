using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class PurchaseHistoryRepository : IRepository<PurchaseHistory>
{
    public Task<PurchaseHistory> Create(PurchaseHistory entity)
    {
        throw new NotImplementedException();
    }

    public Task<PurchaseHistory> Delete(PurchaseHistory entity)
    {
        throw new NotImplementedException();
    }

    public Task<PurchaseHistory?> GetFirstOrDefault(Expression<Func<PurchaseHistory, bool>> filter, Func<IQueryable<PurchaseHistory>, IOrderedQueryable<PurchaseHistory>>? sorts = null, Func<IQueryable<PurchaseHistory>, IIncludableQueryable<PurchaseHistory, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PurchaseHistory>> GetMany(Expression<Func<PurchaseHistory, bool>>? filtres = null, Func<IQueryable<PurchaseHistory>, IOrderedQueryable<PurchaseHistory>>? sorts = null, Func<IQueryable<PurchaseHistory>, IIncludableQueryable<PurchaseHistory, object>>? include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<PurchaseHistory> Update(PurchaseHistory entity)
    {
        throw new NotImplementedException();
    }
}
