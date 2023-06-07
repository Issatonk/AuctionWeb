using Auction.DAL.MSSQL.Entity;
using Auction.Domain;
namespace Auction.BLL;

public interface ILotService
{
    Task<Lot> CreateLot(Lot lot);
    Task<IEnumerable<Lot>> GetPaged(FilterHelper filterHelper, SortingHelper sortingHelper);
}
