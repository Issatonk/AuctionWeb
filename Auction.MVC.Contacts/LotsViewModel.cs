using Auction.DAL.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.MVC.Contracts;

public class LotsViewModel
{
    public IEnumerable<Lot> Lots { get; set; }
}
