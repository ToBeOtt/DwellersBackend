namespace Dwellers.Authentication.Contracts.Responses
{
    public record RegisterResponse(
          string Id,
          string Username,
          string Alias,
          string Email
      );
}

