using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.DAL.MSSQL.Entity;

public class PurchasedLot
{

    public int Id { get; set; }
    public Guid LotId { get; set; }
    public Lot Lot { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public DateTime DateTime { get; set; }
}
