using Auction.DAL.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.TempIService
{
    public interface IAccountBalanceHistoryService
    {
        Task<IEnumerable<AccountBalanceHistory>> GetBalanceHistoryByUsernameAsync(string username);
    }
}
