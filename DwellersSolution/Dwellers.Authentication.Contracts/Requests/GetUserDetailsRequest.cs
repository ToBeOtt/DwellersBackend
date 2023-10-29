namespace Dwellers.Household.Contracts.Requests
{
    public record GetUserDetailsRequest(
     string UserId,
     Guid HouseId);
}
