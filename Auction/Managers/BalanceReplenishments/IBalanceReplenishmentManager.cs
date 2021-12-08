using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Auction.Managers.BalanceReplenishments
{
    public interface IBalanceReplenishmentManager
    {
        public void Add(BalanceReplenishment balanceReplenishment);

        public ICollection<BalanceReplenishment> GetAll();

        public ICollection<BalanceReplenishment> GetByUser(Guid UserId);
    }
}
