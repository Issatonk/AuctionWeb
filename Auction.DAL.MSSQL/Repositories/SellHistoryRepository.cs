using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class SellHistoryRepository : IRepository<SellHistory>
{
    public Task<SellHistory> Create(SellHistory entity)
    {
        throw new NotImplementedException();
    }

    public Task<SellHistory> Delete(SellHistory entity)
    {
        throw new NotImplementedException();
    }

    public Task<SellHistory?> GetFirstOrDefault(Expression<Func<SellHistory, bool>> filter, Func<IQueryable<SellHistory>, IOrderedQueryable<SellHistory>>? sorts = null, Func<IQueryable<SellHistory>, IIncludableQueryable<SellHistory, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SellHistory>> GetMany(Expression<Func<SellHistory, bool>>? filtres = null, Func<IQueryable<SellHistory>, IOrderedQueryable<SellHistory>>? sorts = null, Func<IQueryable<SellHistory>, IIncludableQueryable<SellHistory, object>>? include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<SellHistory> Update(SellHistory entity)
    {
        throw new NotImplementedException();
    }
}