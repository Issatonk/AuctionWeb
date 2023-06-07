using Auction.Storage;
using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Managers.PurchaseHistoris
{
    public class PurchaseHistoryManager : IPurchaseHistoryManager
    {
        private OldAuctionContext _context;

        public PurchaseHistoryManager(OldAuctionContext context)
        {
            _context = context;
        }
        public ICollection<PurchaseHistory> GetAll()
        {
            return _context.PurchaseHistories.ToList();
        }
        public ICollection<PurchaseHistory> GetByUser(Guid userId)
        {
            return _context.PurchaseHistories.Where(ph=>ph.OwnerId == userId).ToList();
        }
        public void Add(PurchaseHistory ph)
        {  
            _context.PurchaseHistories.Add(ph);
            _context.SaveChanges();

        }
        public Lot GetLotByPurchase(PurchaseHistory a)
        {
            return _context.Lots.Where(x => x.Id == a.LotId).FirstOrDefault();
        }
    }
}
