using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class SellHistoryRepository : IRepository<SellHistory>
{
    private readonly DbSet<SellHistory> _sellHistoryDbSet;

    public SellHistoryRepository(AuctionContext context)
    {
        _sellHistoryDbSet = context.SellHistories;
    }
    public async Task<SellHistory> Create(SellHistory entity)
    {
        return (await _sellHistoryDbSet.AddAsync(entity)).Entity;
    }
    public async Task<IEnumerable<SellHistory>> GetMany(
        Expression<Func<SellHistory, bool>>? filtres = null, 
        Func<IQueryable<SellHistory>, IOrderedQueryable<SellHistory>>? sorts = null, 
        Func<IQueryable<SellHistory>, IIncludableQueryable<SellHistory, object>>? include = null, 
        int pageIndex = 0, 
        int pageSize = 20, 
        bool disableTracking = true)
    {
        IQueryable<SellHistory> query = _sellHistoryDbSet;

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

    public Task<SellHistory> Delete(SellHistory entity)
    {
        throw new NotImplementedException();
    }

    public Task<SellHistory?> GetFirstOrDefault(Expression<Func<SellHistory, bool>> filter, Func<IQueryable<SellHistory>, IOrderedQueryable<SellHistory>>? sorts = null, Func<IQueryable<SellHistory>, IIncludableQueryable<SellHistory, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<SellHistory> Update(SellHistory entity)
    {
        throw new NotImplementedException();
    }
}