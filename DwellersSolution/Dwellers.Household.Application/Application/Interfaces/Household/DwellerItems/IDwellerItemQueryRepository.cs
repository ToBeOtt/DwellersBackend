using Dwellers.Household.Domain.Entities.DwellerItems;

namespace Dwellers.Household.Application.Interfaces.Household.DwellerItems
{
    public interface IDwellerItemQueryRepository
    {
        Task<DwellerItem> GetDwellerItem(Guid ItemId);
        Task<ICollection<DwellerItem>> GetAllDwellerItems(Guid houseId);
    }
}
