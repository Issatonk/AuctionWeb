using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Auction.Managers.Bets
{
    public interface IBetManager
    {
        ICollection<Bet> GetAll();

        Bet GetByLot(Guid idLot);

        void MakeBet(Bet bet);
        User GetByBet(int betId);
    }
}
