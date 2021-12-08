using Auction.Storage;
using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Managers.WishLists
{
    public class WishListManager : IWishListManager
    {
        private AuctionContext _context;

        public WishListManager(AuctionContext context)
        {
            _context = context;
        }
        public ICollection<WishList> GetAll()
        {
            return _context.WishLists.ToList();
        }
        public void Add(Guid userid,Guid lotid, double wishprice)
        {
            var wll = _context.WishLists.Where(x => x.LotId == lotid).ToList();
            if (wll.Count == 0)
            {
                WishList temp = new WishList();
                temp.Id = Guid.NewGuid();
                temp.OwnerId = userid;
                temp.LotId = lotid;
                temp.WishPrice = wishprice;
                _context.WishLists.Add(temp);
                _context.SaveChanges();
            }
        }
        public void Remove(Guid lotid)
        {
            var lotToRemove = _context.WishLists.Where(us => us.LotId == lotid).ToList();
            Console.WriteLine("Удаление");
            if (lotToRemove !=null)
            {
                
                _context.WishLists.RemoveRange(lotToRemove);
                _context.SaveChanges();
            }
        }
        public ICollection<WishList> GetWishListByOwner(Guid idOwner)
        {
            return _context.WishLists.Where(WL => WL.OwnerId == idOwner).ToList();
        }
        public ICollection<WishList> GetWishListsByLot(Guid lotId)
        {
            return _context.WishLists.Where(WL => WL.LotId == lotId).ToList();
        }
        public Lot GetLotByWish(WishList list)
        {
            return _context.Lots.Where(xl => xl.Id == list.LotId).FirstOrDefault();
        }

        public WishList GetWishLotUser(Guid lotId, Guid userId)
        {
            return _context.WishLists.Where(lot => lot.LotId == lotId).Where(user => user.OwnerId == userId).FirstOrDefault();
        }
    }
}
