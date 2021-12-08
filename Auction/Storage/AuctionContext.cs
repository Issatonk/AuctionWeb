using Auction.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Storage
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {

        }

        public DbSet<Lot> Lots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BalanceReplenishment> BalanceReplenishments {get;set;}
        
        public DbSet<FileModel> FileModel { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
        //public DbSet<Referral> Referrals { get; set; }
        public DbSet<SellHistory> SellHistories { get; set; }
        public DbSet<SellLot> SellLots { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Bet> Bets { get; set; }

    }
}
