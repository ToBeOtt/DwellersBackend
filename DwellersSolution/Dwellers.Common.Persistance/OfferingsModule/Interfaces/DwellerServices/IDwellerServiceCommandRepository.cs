using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Offerings.Domain.DwellerServices;

namespace Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices
{
    public interface IDwellerServiceCommandRepository
    {
        Task<bool> AddDwellerService(DwellerService service);
        Task<bool> RegisterProvidedService(ProvidedServiceEntity service);
        Task<bool> RemoveDwellerService(DwellerServiceEntity service);
    }
}
