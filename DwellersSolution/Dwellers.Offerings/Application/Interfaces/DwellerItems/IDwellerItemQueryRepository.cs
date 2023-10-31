using Dwellers.Common.DAL.Models.DwellerItems;

namespace Dwellers.Offerings.Application.Interfaces.DwellerItems
{
    public interface IDwellerItemQueryRepository
    {
        Task<DwellerItemEntity> GetDwellerItem(Guid ItemId);
        Task<ICollection<DwellerItemEntity>> GetAllDwellerItems(Guid houseId);
    }
}
