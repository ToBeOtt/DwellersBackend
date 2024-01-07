using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Offerings.Domain.DwellerItems;

namespace Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems
{
    public interface IDwellerItemCommandRepository
    {
        Task<bool> AddDwellerItem(DwellerItem item);
        Task<bool> RegisterItemStatus(BorrowedItemEntity borrowedItem);
        Task<bool> RemoveDwellerItem(DwellerItemEntity item);
    }
}
