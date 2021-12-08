using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.Incomes
{
    public interface IIncomeManager
    {
        void Add(double summary);

        public ICollection<Income> GetAll();
    }
}
