using Dwellers.Household.Domain.Entities.DwellerItems;

namespace Dwellers.Household.Application.Interfaces.Household.DwellerItems
{
    public interface IDwellerItemCommandRepository
    {
        Task<bool> AddDwellerItem(DwellerItem item);
        Task<bool> RegisterItemStatus(BorrowedItem borrowedItem);

        Task<bool> RemoveDwellerItem(DwellerItem item);
    }
}
