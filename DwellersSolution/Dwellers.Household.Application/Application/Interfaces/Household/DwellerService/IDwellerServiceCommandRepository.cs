using Dwellers.Household.Domain.Entities.DwellerServices;

namespace Dwellers.Household.Application.Interfaces.Household.DwellerService
{
    public interface IDwellerServiceCommandRepository
    {
        Task<bool> AddDwellerService(Domain.Entities.DwellerServices.DwellerService service);
        Task<bool> RegisterProvidedService(ProvidedService service);


        Task<bool> RemoveDwellerService(Domain.Entities.DwellerServices.DwellerService service);
    }
}
