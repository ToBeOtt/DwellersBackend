namespace Dwellers.Household.Contracts.Requests
{
    public record RegisterMemberToHouseRequest(
     Guid Invitation,
     string Email);
}
