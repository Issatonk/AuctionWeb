using Auction.DAL.MSSQL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.DAL.MSSQL;

public class AuctionContext : DbContext
{
    public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
    {

    }

    public DbSet<Lot> Lots { get; set; }
    public DbSet<IdentityUserClaim<Guid>> UsersClaims { get; set; }
    public DbSet<IdentityUserRole<Guid>> UserRoles { get; set; }
    public DbSet<IdentityRole<Guid>> Roles { get; set; } // Добавлено свойство для ролей

    public DbSet<Balance> Balances { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<AccountBalanceHistory> AccountBalanceHistories { get; set; }

    public DbSet<FileModel> FileModel { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<PurchasedLot> PurchasedLot { get; set; }
    public DbSet<SellHistory> SellHistories { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<Bet> Bets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserRole<Guid>>()
            .HasKey(r => new { r.UserId, r.RoleId });
        modelBuilder.Entity<User>()
            .HasOne(u => u.Balance)
            .WithOne()
            .HasForeignKey<Balance>(b => b.UserId);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase("AuctionDatabase");
        }
    }
}
