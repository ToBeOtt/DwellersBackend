using Dwellers.Common.Data.Models.DwellerServices;

namespace Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices
{
    public interface IDwellerServiceCommandRepository
    {
        Task<bool> AddDwellerService(DwellerServiceEntity service);
        Task<bool> RegisterProvidedService(ProvidedServiceEntity service);
        Task<bool> RemoveDwellerService(DwellerServiceEntity service);
    }
}
