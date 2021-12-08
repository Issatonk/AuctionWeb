using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.SellLots
{
    public interface ISellLotManager
    {
        ICollection<SellLot> GetAll();
        void Add(SellLot lot);
    }
}
