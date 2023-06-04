using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class WishListRepository : IRepository<WishList>
{
    private readonly DbSet<WishList> _wishListDbSet;

    public WishListRepository(AuctionContext context)
    {
        _wishListDbSet = context.WishLists;
    }
    public async Task<WishList> Create(WishList entity)
    {
        return (await _wishListDbSet.AddAsync(entity)).Entity; 
    }

    public async Task<WishList> Delete(WishList entity)
    {
        var removeEntity = await _wishListDbSet.FindAsync(entity);
        _wishListDbSet.Remove(removeEntity);
        return removeEntity;
    }

    public async Task<IEnumerable<WishList>> GetMany(
        Expression<Func<WishList, bool>>? filtres = null, 
        Func<IQueryable<WishList>, IOrderedQueryable<WishList>>? sorts = null, 
        Func<IQueryable<WishList>, IIncludableQueryable<WishList, object>>? include = null, 
        int pageIndex = 0, 
        int pageSize = 20, 
        bool disableTracking = true)
    {
        IQueryable<WishList> query = _wishListDbSet;

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

    public Task<WishList> Update(WishList entity)
    {
        throw new NotImplementedException();
    }
    public Task<WishList?> GetFirstOrDefault(Expression<Func<WishList, bool>> filter, Func<IQueryable<WishList>, IOrderedQueryable<WishList>>? sorts = null, Func<IQueryable<WishList>, IIncludableQueryable<WishList, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }
}