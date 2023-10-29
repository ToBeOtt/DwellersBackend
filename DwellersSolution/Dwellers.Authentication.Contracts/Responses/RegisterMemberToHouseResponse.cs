namespace Dwellers.Authentication.Contracts.Responses
{
    public record RegisterMemberToHouseResponse(
        string Id,
        string Email,
        string Name);
}