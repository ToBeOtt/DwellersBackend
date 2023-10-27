namespace Dwellers.Household.Contracts.Responses.Authentication
{
    public record RegisterResponse(
          string Id,
          string Username,
          string Alias,
          string Email
      );
}

