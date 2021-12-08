using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.PurchaseHistoris
{
    public interface IPurchaseHistoryManager
    {
        void Add(PurchaseHistory lot);
        public ICollection<PurchaseHistory> GetAll();
        Lot GetLotByPurchase(PurchaseHistory a);
        ICollection<PurchaseHistory> GetByUser(Guid userId);
    }
}
