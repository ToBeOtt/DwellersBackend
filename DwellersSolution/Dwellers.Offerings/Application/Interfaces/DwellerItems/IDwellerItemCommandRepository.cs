using Dwellers.Common.DAL.Models.DwellerItems;

namespace Dwellers.Offerings.Application.Interfaces.DwellerItems
{
    public interface IDwellerItemCommandRepository
    {
        Task<bool> AddDwellerItem(DwellerItemEntity item);
        Task<bool> RegisterItemStatus(BorrowedItemEntity borrowedItem);
        Task<bool> RemoveDwellerItem(DwellerItemEntity item);
    }
}
