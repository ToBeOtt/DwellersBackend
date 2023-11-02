namespace Dwellers.Household.Contracts.Requests
{
    public record RegisterHouseRequest(
        string Name,
        string Description,
        string Email
        );

    public record RegisterMemberToHouseRequest(
       Guid Invitation,
       string Email
       );
}


