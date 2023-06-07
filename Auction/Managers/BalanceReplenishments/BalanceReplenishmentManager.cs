using Auction.Storage;
using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.BalanceReplenishments
{
    public class BalanceReplenishmentManager : IBalanceReplenishmentManager
    {
        private OldAuctionContext _context;

        public BalanceReplenishmentManager(OldAuctionContext context)
        {
            _context = context;
        }
        public void Add(BalanceReplenishment balanceReplenishment)
        {
            balanceReplenishment.Date = DateTime.Now;
            balanceReplenishment.User = _context.Users.Where(us => us.Id == balanceReplenishment.UserId).FirstOrDefault();
            _context.BalanceReplenishments.Add(balanceReplenishment);
            balanceReplenishment.User.Balance += Math.Abs(balanceReplenishment.Amount);
            _context.SaveChanges();
        }

        public ICollection<BalanceReplenishment> GetAll()
        {
            return _context.BalanceReplenishments.ToList();
        }

        public ICollection<BalanceReplenishment> GetByUser(Guid UserId)
        {
            return _context.BalanceReplenishments.Where(balance => balance.User.Id == UserId).ToList();
        }
    }
}
