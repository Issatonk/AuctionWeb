using Auction.Storage.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.Lots
{
    public interface ILotManager
    {
        ICollection<Lot> GetAll();
        ICollection<Lot> GetByCategory(string category);
        ICollection<Lot> GetMyLots(Guid userId);
        ICollection<Lot> SortByPriceInAscending(string category);
        ICollection<Lot> SortByPriceInDescending(string category);
        ICollection<Lot> SortByDateInAscending(string category);
        ICollection<Lot> SortByDateInDescending(string category);
        Lot GetLot(Guid LotId);
        ICollection<Lot> GetLotByOwner(Guid OwnerId);
        Task Add(Lot lot);
        bool IsActive(Lot lotId);
        void UpdateLot(Guid LotId, double sum);
    }
}
