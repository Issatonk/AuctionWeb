using Auction.Storage;
using Auction.Storage.Entity;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Managers.SellLots
{
    public class SellLotManager : ISellLotManager
    {
        private AuctionContext _context;

        public SellLotManager(AuctionContext context)
        {
            _context = context;
        }
        public void Add(SellLot lot)
        {
            _context.SellLots.Add(lot);
            _context.SaveChanges();
        }
        public ICollection<SellLot> GetAll()
        {
            return _context.SellLots.ToList();
        }
    }
}