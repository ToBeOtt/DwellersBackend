using Dwellers.Common.DAL.Models.DwellerServices;

namespace Dwellers.Offerings.Application.Interfaces.DwellerServices
{
    public interface IDwellerServiceQueryRepository
    {
        Task<DwellerServiceEntity> GetDwellerService(Guid ServiceId);
        Task<ICollection<DwellerServiceEntity>> GetAllDwellerServices(Guid houseId);
    }
}
