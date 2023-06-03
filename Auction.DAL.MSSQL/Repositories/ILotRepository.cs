using Auction.DAL.MSSQL.Entity;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Auction.DAL.MSSQL.Repositories;

public interface ILotRepository : IRepository<Lot>
{
    Task<IEnumerable<Lot>> GetPagedList(
        Expression<Func<Lot, bool>>? filtres = null,
        Func<IQueryable<Lot>, IOrderedQueryable<Lot>>? sorts = null,
        Func<IQueryable<Lot>, IIncludableQueryable<Lot, object>>? include = null,
        int pageIndex = 0,
        int pageSize = 20,
        bool disableTracking = false
        );
}
