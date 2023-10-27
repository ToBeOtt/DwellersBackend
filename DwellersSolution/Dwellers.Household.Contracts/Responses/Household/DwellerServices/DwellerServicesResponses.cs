using Dwellers.Household.Domain.Entities.DwellerServices;

namespace Dwellers.Household.Contracts.Responses.Household.DwellerServices
{
    public record AddDwellerServiceResponse(
       bool Success);

    public record GetDwellerServiceResponse(
       DwellerService DwellerService);

    public record GetAllDwellerServiceResponse(
       ICollection<DwellerService> DwellerServices);
}
