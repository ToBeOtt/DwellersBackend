namespace Dwellers.Offerings.Contracts.Requests
{
    public record AddDwellerServiceRequest(
         Guid HouseId,
         string Name,
         string Description,
         string ServiceScope);
}