using Dwellers.Common.DAL.Models.DwellerServices;

namespace Dwellers.Offerings.Application.Interfaces.DwellerServices
{
    public interface IDwellerServiceCommandRepository
    {
        Task<bool> AddDwellerService(DwellerServiceEntity service);
        Task<bool> RegisterProvidedService(ProvidedServiceEntity service);
        Task<bool> RemoveDwellerService(DwellerServiceEntity service);
    }
}
