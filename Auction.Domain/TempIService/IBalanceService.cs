using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.TempIService;

public interface IBalanceService
{
    Task<bool> UpdateBalance(string username, decimal amount);
}
