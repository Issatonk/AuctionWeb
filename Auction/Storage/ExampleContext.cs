using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Storage
{
    public class ExampleContext
    {
        public List<Lot> Lots { get; set; }
        public List<User> Users { get; set; }

        public ExampleContext()
        {
            Lots = new List<Lot>();
            Users = new List<User>();
        }
    }
}
