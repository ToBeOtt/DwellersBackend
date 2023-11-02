using Dwellers.Common.Data.Models.DwellerServices;

namespace Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices
{
    public interface IDwellerServiceQueryRepository
    {
        Task<DwellerServiceEntity> GetDwellerService(Guid ServiceId);
        Task<ICollection<DwellerServiceEntity>> GetAllDwellerServices(Guid houseId);
    }
}
