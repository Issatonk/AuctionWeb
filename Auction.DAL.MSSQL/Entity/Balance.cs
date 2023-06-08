namespace Auction.DAL.MSSQL.Entity;

public class Balance
{
    public decimal Amount { get; set; }

    public string CurrencyCode { get; set; } = "RUB";
}
