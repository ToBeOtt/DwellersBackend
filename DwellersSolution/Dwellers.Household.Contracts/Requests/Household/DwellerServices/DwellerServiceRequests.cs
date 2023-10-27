namespace Dwellers.Household.Contracts.Requests.Household.DwellerServices
{
    public record AddDwellerServiceRequest(
       string Name,
       string Description,
       string ServiceScope);


    public record RemoveDwellerServiceRequest(
        Guid DwellerServiceId);


    public record GetDwellerServiceRequest(
        Guid DwellerServiceId);


    public record GetAllDwellerServicesRequest();
}

