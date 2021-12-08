using Auction.Storage;
using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.Bets
{
    public class BetManager : IBetManager
    {
        private AuctionContext _context;

        public BetManager(AuctionContext context)
        {
            _context = context;
        }
        public ICollection<Bet> GetAll()
        {
            return _context.Bets.ToList();
        }

        public User GetByBet(int betId)
        {
            return _context.Bets.Where(x => x.Id == betId).FirstOrDefault().Man;
        }

        public Bet GetByLot(Guid lotId)
        {
            var lot =_context.Lots.Find(lotId);
            return _context.Bets.Where(x=>x.LotsId == lotId).FirstOrDefault();
        }

        public void MakeBet(Bet bet)
        {
            bet.Time = DateTime.Now;
            Console.WriteLine("Id"+bet.Id);
            Console.WriteLine("LotID"+bet.LotsId);
            Console.WriteLine("ManId"+bet.ManId);
            Console.WriteLine("Price"+bet.Price);
            Console.WriteLine("Time"+bet.Time);
            var user = _context.Users.Where(us => us.Id == bet.ManId).FirstOrDefault();
            bet.Man = user;
            var lot = _context.Lots.Where(lot => lot.Id == bet.LotsId).FirstOrDefault();
            bet.Lots = lot;
            var temp = _context.Bets.Where(x => x.LotsId == bet.LotsId).ToList();
            if (temp.Count == 0) _context.Bets.Add(bet);
            else
            {
                var tt = _context.Bets.Where(x => x.LotsId == bet.LotsId).FirstOrDefault();
                tt.ManId = bet.ManId;
                tt.Man = bet.Man;
                tt.Price = bet.Price;
                tt.Time = bet.Time;
                
                _context.Update(tt);
            }
            _context.SaveChanges();
        }
    }
}
