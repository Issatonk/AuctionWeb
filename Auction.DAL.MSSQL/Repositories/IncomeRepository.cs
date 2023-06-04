using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class IncomeRepository : IRepository<Income>
{
    private readonly DbSet<Income> _incomeDbSet;

    public IncomeRepository(AuctionContext context)
    {
        _incomeDbSet = context.Incomes;
    }
    public async Task<Income> Create(Income entity)
    {
        var result = await _incomeDbSet.AddAsync(entity);
        return result.Entity;
    }
    public async Task<IEnumerable<Income>> GetMany(Expression<Func<Income, bool>>? filtres = null, Func<IQueryable<Income>, IOrderedQueryable<Income>>? sorts = null, Func<IQueryable<Income>, IIncludableQueryable<Income, object>>? include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = false)
    {
        IQueryable<Income> query = _incomeDbSet;

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

    public Task<Income> Delete(Income entity)
    {
        throw new NotImplementedException();
    }

    public Task<Income?> GetFirstOrDefault(Expression<Func<Income, bool>> filter, Func<IQueryable<Income>, IOrderedQueryable<Income>>? sorts = null, Func<IQueryable<Income>, IIncludableQueryable<Income, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<Income> Update(Income entity)
    {
        throw new NotImplementedException();
    }
}