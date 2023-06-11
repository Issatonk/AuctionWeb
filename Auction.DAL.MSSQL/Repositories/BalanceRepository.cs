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

namespace Auction.DAL.MSSQL.Repositories
{
    public class BalanceRepository : IRepository<Balance>
    {
        private readonly DbSet<Balance> _balanceDbSet;

        public BalanceRepository(AuctionContext auctionContext)
        {
            _balanceDbSet = auctionContext.Balances;
        }
        public Task<Balance> Create(Balance entity)
        {
            throw new NotImplementedException();
        }

        public Task<Balance> Delete(Balance entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Balance?> GetFirstOrDefault(Expression<Func<Balance, bool>> filter, Func<IQueryable<Balance>, IOrderedQueryable<Balance>>? sorts = null, Func<IQueryable<Balance>, IIncludableQueryable<Balance, object>>? include = null, bool disableTracking = false)
        {
            IQueryable<Balance> query = _balanceDbSet;

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

        public Task<IEnumerable<Balance>> GetMany(Expression<Func<Balance, bool>>? filtres = null, Func<IQueryable<Balance>, IOrderedQueryable<Balance>>? sorts = null, Func<IQueryable<Balance>, IIncludableQueryable<Balance, object>>? include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<Balance> Update(Balance entity)
        {
            throw new NotImplementedException();
        }
    }
}
