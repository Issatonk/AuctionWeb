using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class PurchaseHistoryRepository : IRepository<PurchaseHistory>
{
    private readonly DbSet<PurchaseHistory> _purchaseHistoryDbSet;

    public PurchaseHistoryRepository(AuctionContext context)
    {
        _purchaseHistoryDbSet = context.PurchaseHistories;
    }
    public async Task<PurchaseHistory> Create(PurchaseHistory entity)
    {
        return (await _purchaseHistoryDbSet.AddAsync(entity)).Entity;
    }

    public async Task<IEnumerable<PurchaseHistory>> GetMany(
        Expression<Func<PurchaseHistory, bool>>? filtres = null, 
        Func<IQueryable<PurchaseHistory>, IOrderedQueryable<PurchaseHistory>>? sorts = null, 
        Func<IQueryable<PurchaseHistory>, IIncludableQueryable<PurchaseHistory, object>>? include = null, 
        int pageIndex = 0, 
        int pageSize = 20, 
        bool disableTracking = true)
    {
        IQueryable<PurchaseHistory> query = _purchaseHistoryDbSet;

        if (disableTracking)
        {
            query = query.AsNoTracking();
        }
        if (include is not null)
        {
            query = include(query);
        }
        if (filtres is not null)
        {
            query = query.Where(filtres);
        }
        if (sorts is not null)
        {
            query = sorts(query);
        }

        return await query
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public Task<PurchaseHistory> Delete(PurchaseHistory entity)
    {
        throw new NotImplementedException();
    }

    public Task<PurchaseHistory?> GetFirstOrDefault(Expression<Func<PurchaseHistory, bool>> filter, Func<IQueryable<PurchaseHistory>, IOrderedQueryable<PurchaseHistory>>? sorts = null, Func<IQueryable<PurchaseHistory>, IIncludableQueryable<PurchaseHistory, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<PurchaseHistory> Update(PurchaseHistory entity)
    {
        throw new NotImplementedException();
    }
}
