using Auction.DAL.MSSQL.Entity;
using System.Reflection.Metadata;

namespace Auction.Domain;

public class FilterHelper
{
    public string? Category { get; set; }

    public Guid? UserId { get; set; }

    public bool? IsSold { get; set; }
}
