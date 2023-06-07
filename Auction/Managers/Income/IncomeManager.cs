using Auction.Storage;
using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Managers.Incomes
{
    public class IncomeManager : IIncomeManager
    {
        private OldAuctionContext _context;

        public IncomeManager(OldAuctionContext context)
        {
            _context = context;
        }
        public ICollection<Income> GetAll()
        {
            return _context.Incomes.ToList();
        }
        public void Add(double summary)
        {
            Income temp = new Income ();
            temp.Id = DateTime.Now;
            temp.IncomeSum = summary;
            _context.Incomes.Add(temp);
            _context.SaveChanges();
        }
    }
}