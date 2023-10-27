namespace Dwellers.Household.Contracts.Responses.Authentication
{
    public record LoginResponse(
         string Id,
         string Username,
         string Email,
         string Token
     );

}
