using Auction.Storage;
using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Managers.SellHistoris
{
    public class SellHistoryManager : ISellHistoryManager
    {
        private AuctionContext _context;

        public SellHistoryManager(AuctionContext context)
        {
            _context = context;
        }
        public ICollection<SellHistory> GetAll()
        {
            return _context.SellHistories.ToList();
        }

        public ICollection<SellHistory> GetByUser(Guid userId)
        {
            return _context.SellHistories.Where(sh=>sh.OwnerId == userId).ToList();
        }

        public void Add(SellHistory lot)
        {
            _context.SellHistories.Add(lot);
            _context.SaveChanges();
        }
        public Lot GetLotBySellH(SellHistory a)
        {
            return _context.Lots.Where(x => x.Id == a.LotId).FirstOrDefault();
        }
    }
}
