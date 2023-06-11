﻿using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public class PurchaseHistoryRepository : IRepository<PurchasedLot>
{
    private readonly DbSet<PurchasedLot> _purchaseHistoryDbSet;

    public PurchaseHistoryRepository(AuctionContext context)
    {
        _purchaseHistoryDbSet = context.PurchasedLot;
    }
    public async Task<PurchasedLot> Create(PurchasedLot entity)
    {
        return (await _purchaseHistoryDbSet.AddAsync(entity)).Entity;
    }

    public async Task<IEnumerable<PurchasedLot>> GetMany(
        Expression<Func<PurchasedLot, bool>>? filtres = null, 
        Func<IQueryable<PurchasedLot>, IOrderedQueryable<PurchasedLot>>? sorts = null, 
        Func<IQueryable<PurchasedLot>, IIncludableQueryable<PurchasedLot, object>>? include = null, 
        int pageIndex = 0, 
        int pageSize = 20, 
        bool disableTracking = true)
    {
        IQueryable<PurchasedLot> query = _purchaseHistoryDbSet;

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
    public Task<PurchasedLot> Delete(PurchasedLot entity)
    {
        throw new NotImplementedException();
    }

    public Task<PurchasedLot?> GetFirstOrDefault(Expression<Func<PurchasedLot, bool>> filter, Func<IQueryable<PurchasedLot>, IOrderedQueryable<PurchasedLot>>? sorts = null, Func<IQueryable<PurchasedLot>, IIncludableQueryable<PurchasedLot, object>>? include = null, bool disableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<PurchasedLot> Update(PurchasedLot entity)
    {
        throw new NotImplementedException();
    }
}
