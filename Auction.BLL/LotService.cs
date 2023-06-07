using Auction.DAL.MSSQL.Entity;
using Auction.Domain;
using Auction.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Auction.Infrostructure;
namespace Auction.BLL;



public class LotService : ILotService
{
    private readonly IUnitOfWork _unitOfWork;

    public LotService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Lot> CreateLot(Lot lot)
    {
        var lotRepository = _unitOfWork.GetRepository<Lot>();
        return await lotRepository.Create(lot);
    }

    public async Task<IEnumerable<Lot>> GetPaged(FilterHelper filterHelper, SortingHelper sortingHelper)
    {
        var lotRepository = _unitOfWork.GetRepository<Lot>();
        Expression<Func<Lot, bool>> filter = lot => true;

        if(filterHelper != null)
        {
            if(filterHelper.Category != null)
            {
                filter = filter.And(lot => lot.Category == filterHelper.Category);
            }
            if(filterHelper.User != null)
            {
                filter = filter.And(lot => lot.Owner.Id == filterHelper.User.Id);
            }
            if(filterHelper.IsSold != null)
            {
                filter = filter.And(lot => lot.IsSold == filterHelper.IsSold);
            }
        }
        Func<IQueryable<Lot>, IOrderedQueryable<Lot>> sort = query =>
        {
            IOrderedQueryable<Lot> orderedQuery = query.OrderBy(lot => lot.Id); // Задаем начальную сортировку

            if (sortingHelper.Date != null)
            {
                orderedQuery = sortingHelper.Date == true ?
                    orderedQuery.ThenBy(lot => lot.FinalDate) :
                    orderedQuery.ThenByDescending(lot => lot.FinalDate);
            }

            if (sortingHelper.Price != null)
            {
                orderedQuery = sortingHelper.Price == true ?
                    orderedQuery.ThenBy(lot => lot.CurrentPrice) :
                    orderedQuery.ThenByDescending(lot => lot.CurrentPrice);
            }

            return orderedQuery;
        };

        var result = await lotRepository.GetMany(filtres: filter, sorts: sort);
        return result;
    }
}
