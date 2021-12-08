using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.Users
{
    public interface IUserManager
    {
        void MakeDeposit(Guid UserId,double sum);
        Guid GetIdByName(string login);
        double GetBalance(Guid UserId);
        User GetById(Guid userId);
    }
}
