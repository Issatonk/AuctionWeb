using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class BetRepository : IRepository<Bet>
{
    private readonly DbSet<Bet> _betDbSet;

    public BetRepository(AuctionContext context)
    {
        _betDbSet = context.Bets;
    }
    public async Task<Bet> Create(Bet entity)
    {
        return (await _betDbSet.AddAsync(entity)).Entity;
    }

    public async Task<IEnumerable<Bet>> GetMany(
        Expression<Func<Bet, bool>>? filtres = null, 
        Func<IQueryable<Bet>, IOrderedQueryable<Bet>>? sorts = null, 
        Func<IQueryable<Bet>, IIncludableQueryable<Bet, object>>? include = null, 
        int pageIndex = 0, 
        int pageSize = 20, 
        bool disableTracking = true)
    {
        IQueryable<Bet> query = _betDbSet;

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
    public Task<Bet> Delete(Bet entity)
    {
        throw new NotImplementedException();
    }

    public Task<Bet?> GetFirstOrDefault(Expression<Func<Bet, bool>> filter, Func<IQueryable<Bet>, IOrderedQueryable<Bet>>? sorts = null, Func<IQueryable<Bet>, IIncludableQueryable<Bet, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<Bet> Update(Bet entity)
    {
        throw new NotImplementedException();
    }
}
