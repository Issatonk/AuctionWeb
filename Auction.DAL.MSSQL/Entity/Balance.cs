using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auction.DAL.MSSQL.Entity;

public class Balance
{

    [Key]
    public Guid UserId { get; set; }

    public decimal Amount { get; set; }



    public string CurrencyCode { get; set; } = "RUB";
}
