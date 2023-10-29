namespace Dwellers.Authentication.Contracts.Responses
{
    public record LoginResponse(
         string Id,
         string Username,
         string Email,
         string Token
     );

}
