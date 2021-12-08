using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.WishLists
{
    public interface IWishListManager
    {
        public ICollection<WishList> GetAll();

        public ICollection<WishList> GetWishListByOwner(Guid idOwner);

        void Remove(Guid lotid);

        void Add(Guid userid, Guid lotid, double wishprice);

        ICollection<WishList> GetWishListsByLot(Guid lotId);
        Lot GetLotByWish(WishList list);

        WishList GetWishLotUser(Guid lotId, Guid userId);
    }
}
