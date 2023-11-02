using Dwellers.Common.Data.Models.DwellerItems;

namespace Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems
{
    public interface IDwellerItemCommandRepository
    {
        Task<bool> AddDwellerItem(DwellerItemEntity item);
        Task<bool> RegisterItemStatus(BorrowedItemEntity borrowedItem);
        Task<bool> RemoveDwellerItem(DwellerItemEntity item);
    }
}
