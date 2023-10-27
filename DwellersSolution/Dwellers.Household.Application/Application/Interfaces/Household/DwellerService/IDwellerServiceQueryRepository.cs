namespace Dwellers.Household.Application.Interfaces.Household.DwellerService
{
    public interface IDwellerServiceQueryRepository
    {
        Task<Domain.Entities.DwellerServices.DwellerService> GetDwellerService(Guid ServiceId);
        Task<ICollection<Domain.Entities.DwellerServices.DwellerService>> GetAllDwellerServices(Guid houseId);
    }
}
