namespace Dwellers.Household.Contracts.Responses.Authentication
{
    public record RegisterMemberToHouseResponse(
        string Id,
        string Email,
        string Name);
}