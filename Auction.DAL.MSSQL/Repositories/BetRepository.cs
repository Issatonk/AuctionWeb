using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class BetRepository : IRepository<Bet>
{
    public Task<Bet> Create(Bet entity)
    {
        throw new NotImplementedException();
    }

    public Task<Bet> Delete(Bet entity)
    {
        throw new NotImplementedException();
    }

    public Task<Bet?> GetFirstOrDefault(Expression<Func<Bet, bool>> filter, Func<IQueryable<Bet>, IOrderedQueryable<Bet>>? sorts = null, Func<IQueryable<Bet>, IIncludableQueryable<Bet, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Bet>> GetMany(Expression<Func<Bet, bool>>? filtres = null, Func<IQueryable<Bet>, IOrderedQueryable<Bet>>? sorts = null, Func<IQueryable<Bet>, IIncludableQueryable<Bet, object>>? include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<Bet> Update(Bet entity)
    {
        throw new NotImplementedException();
    }
}
