using Auction.DAL.MSSQL.Entity;
using Auction.Domain.TempIService;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL
{
    public class AccountBalanceHistoryService : IAccountBalanceHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountBalanceHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        public async Task<IEnumerable<AccountBalanceHistory>> GetBalanceHistoryByUsernameAsync(string username) 
        {
            var balanceHistoryRepository = _unitOfWork.GetRepository<AccountBalanceHistory>();

            Expression<Func<AccountBalanceHistory, bool>> filter = x=>x.User.UserName == username;

            Func<IQueryable<AccountBalanceHistory>, IIncludableQueryable<AccountBalanceHistory, object>> includeUser = query =>
            {
                return query.Include(x => x.User);
            };

            var result = await balanceHistoryRepository.GetMany(filter, include: includeUser);

            return result;
        }
    }
}
