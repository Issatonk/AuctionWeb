using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.MSSQL.Repositories;
public class LotRepository : IRepository<Lot>
{
    private readonly DbSet<Lot> _lotDbSet;

    public LotRepository(AuctionContext context)
    {
        _lotDbSet = context.Lots;
    }

    public Task<Lot> Create(Lot entity)
    {
        throw new NotImplementedException();
    }

    public Task<Lot> Delete(Lot entity)
    {
        throw new NotImplementedException();
    }

    public Task<Lot> Update(Lot entity)
    {
        throw new NotImplementedException();
    }
    //
    public async Task<IEnumerable<Lot>> GetMany(Expression<Func<Lot, bool>>? filtres = null, 
        Func<IQueryable<Lot>, IOrderedQueryable<Lot>>? sorts = null, 
        Func<IQueryable<Lot>, IIncludableQueryable<Lot, object>>? include = null, 
        int pageIndex = 0, 
        int pageSize = 20, 
        bool disableTracking = true)
    {
        IQueryable<Lot> query = _lotDbSet;

        if (disableTracking)
        {
            query = query.AsNoTracking();
        }
        if(include is not null)
        {
            query = include(query);
        }
        if(filtres is not null)
        {
            query = query.Where(filtres);
        }
        if(sorts is not null)
        {
            query = sorts(query);
        }

        return await query
            .Skip(pageIndex*pageSize)
            .Take(pageSize)
            .ToListAsync();

    }

    public async Task<Lot?> GetFirstOrDefault(Expression<Func<Lot, bool>> filter, 
        Func<IQueryable<Lot>, IOrderedQueryable<Lot>>? sorts = null, 
        Func<IQueryable<Lot>, IIncludableQueryable<Lot, object>>? include = null, 
        bool disableTracking = true)
    {
        IQueryable<Lot> query = _lotDbSet;

        if (disableTracking)
        {
            query = query.AsNoTracking();
        }
        if (include is not null)
        {
            query = include(query);
        }
        if (filter is not null)
        {
            query = query.Where(filter);
        }
        if (sorts is not null)
        {
            query = sorts(query);
        }

        return await query.FirstOrDefaultAsync();
    }
}
