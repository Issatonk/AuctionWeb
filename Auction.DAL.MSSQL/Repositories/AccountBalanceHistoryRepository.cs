using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class AccountBalanceHistoryRepository : IRepository<AccountBalanceHistory>
{
    private readonly DbSet<AccountBalanceHistory> _abHistoryDbSet;

    public AccountBalanceHistoryRepository(AuctionContext context)
    {
        _abHistoryDbSet = context.AccountBalanceHistories;
    }
    public async Task<AccountBalanceHistory> Create(AccountBalanceHistory entity)
    {
        await _abHistoryDbSet.AddAsync(entity);
        return entity;
    }

    public Task<AccountBalanceHistory> Delete(AccountBalanceHistory entity)
    {
        throw new NotImplementedException();
    }

    public Task<AccountBalanceHistory?> GetFirstOrDefault(Expression<Func<AccountBalanceHistory, bool>> filter, Func<IQueryable<AccountBalanceHistory>, IOrderedQueryable<AccountBalanceHistory>>? sorts = null, Func<IQueryable<AccountBalanceHistory>, IIncludableQueryable<AccountBalanceHistory, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AccountBalanceHistory>> GetMany(
        Expression<Func<AccountBalanceHistory, bool>>? filtres = null, 
        Func<IQueryable<AccountBalanceHistory>, IOrderedQueryable<AccountBalanceHistory>>? sorts = null, 
        Func<IQueryable<AccountBalanceHistory>, IIncludableQueryable<AccountBalanceHistory, object>>? include = null, 
        int pageIndex = 0, 
        int pageSize = 20, 
        bool disableTracking = true)
    {
        IQueryable<AccountBalanceHistory> query = _abHistoryDbSet;

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

    public Task<AccountBalanceHistory> Update(AccountBalanceHistory entity)
    {
        throw new NotImplementedException();
    }
}
