using Dwellers.Common.Data.Models.DwellerItems;

namespace Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems
{
    public interface IDwellerItemQueryRepository
    {
        Task<DwellerItemEntity> GetDwellerItem(Guid ItemId);
        Task<ICollection<DwellerItemEntity>> GetAllDwellerItems(Guid houseId);
    }
}
