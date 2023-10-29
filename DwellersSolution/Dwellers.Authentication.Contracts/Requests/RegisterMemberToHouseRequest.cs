namespace Dwellers.Authentication.Contracts.Requests
{
    public record RegisterMemberToHouseRequest(
     Guid Invitation,
     string Email);
}
