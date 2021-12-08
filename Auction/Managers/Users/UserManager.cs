using Auction.Storage;
using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.Users
{
    public class UserManager : IUserManager
    {
        private AuctionContext _context;
        public UserManager(AuctionContext context)
        {
            _context = context;
        }
        public void MakeDeposit(Guid UserId, double sum)
        {
            _context.Users.Find(UserId).Balance+=sum;
            _context.SaveChanges();
        }

        public double GetBalance(Guid UserId)
        {
            return _context.Users.Find(UserId).Balance;
        }

        public User GetById(Guid userId)
        {
            return _context.Users.Find(userId);
        }

        public Guid GetIdByName(string login)
        {
            return _context.Users.Where(log => log.Name == login).FirstOrDefault().Id;
        }
    }
}
