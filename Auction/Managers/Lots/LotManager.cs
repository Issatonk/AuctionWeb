using Auction.Storage;
using Auction.Storage.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.Lots
{
    public class LotManager : ILotManager
    {

        private AuctionContext _context;

        public LotManager(AuctionContext context)
        {
            _context = context;
        }

        public async Task Add(Lot lot)
        {
            
            Console.WriteLine("Id лота"+ lot.Id);
            Console.WriteLine("OwnerId" + lot.OwnerID);
            Console.WriteLine("Цена"+lot.CurrentPrice);
            Console.WriteLine("Дата" + lot.FinalDate);
            lot.Owner = _context.Users.Where(us => us.Id == lot.OwnerID).FirstOrDefault();
            _context.Lots.Add(lot);
           await _context.SaveChangesAsync();
            
        }
        public ICollection<Lot> GetByCategory(string category)
        {
            //if (category == "All") return GetAll();
            return GetAll().Where(lot => lot.Category == category).ToList();
        }
        public ICollection<Lot> GetMyLots(Guid userId)
        {
            return GetAll().Where(lot => lot.OwnerID == userId).ToList();
        }
        public ICollection<Lot> GetAll()
        {
            var sl =_context.SellLots.ToList();
            var cl = _context.Lots.ToList();
            List<Lot> tpr = new List<Lot>();
            for (int i = 0; i < cl.Count; i++)
            {
                if (sl.Where(x=>x.LotId==cl[i].Id).ToList().Count==0)
                {
                    tpr.Add(cl[i]);
                }
            }
            return tpr;
        }

        public ICollection<Lot> SortByPriceInAscending(string category)
        {
            return GetByCategory(category).OrderBy(lot => lot.CurrentPrice).ToList();
        }
        public ICollection<Lot> SortByPriceInDescending(string category)
        {
            return GetByCategory(category).OrderByDescending(lot => lot.CurrentPrice).ToList();
        }
        public ICollection<Lot> SortByDateInAscending(string category)
        {
            return GetByCategory(category).OrderBy(lot => lot.FinalDate).ToList();
        }
        public ICollection<Lot> SortByDateInDescending(string category)
        {
            return GetByCategory(category).OrderByDescending(lot => lot.FinalDate).ToList();
        }


        public Lot GetLot(Guid LotId)
        {
            return _context.Lots.Find(LotId);
        }

        public ICollection<Lot> GetLotByOwner(Guid id)
        {
            return _context.Lots.Where(lot => lot.Owner.Id == id).ToList();
        }

        public bool IsActive(Lot lot)
        {
            if (lot.FinalDate > DateTime.Now)
                return true;
            else return false;
        }

        public void UpdateLot(Guid LotId, double sum)
        {
            var lot = _context.Lots.Where(lot => lot.Id == LotId).FirstOrDefault();
            lot.CurrentPrice = sum;
            _context.Lots.Update(lot);
            _context.SaveChanges();
        }
    }

    public enum SortState
    {
        NoSort,
        PriceAsc,
        PriceDes,
        DateAsc,
        DateDes
    }
}
