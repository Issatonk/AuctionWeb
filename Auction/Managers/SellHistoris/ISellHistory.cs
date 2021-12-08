using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.SellHistoris
{
    public interface ISellHistoryManager
    {
        void Add(SellHistory lot);

        ICollection<SellHistory> GetByUser(Guid userId);
        Lot GetLotBySellH(SellHistory a);
        public ICollection<SellHistory> GetAll();
    }
}
