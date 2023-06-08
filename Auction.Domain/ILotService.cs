using Auction.DAL.MSSQL.Entity;
namespace Auction.Domain;

public interface ILotService
{
    Task<Lot> CreateLot(Lot lot);
    Task<IEnumerable<Lot>> GetPaged(FilterHelper filterHelper, SortingHelper sortingHelper);

    Task<Lot> GetAsync(Guid lotId);
}
