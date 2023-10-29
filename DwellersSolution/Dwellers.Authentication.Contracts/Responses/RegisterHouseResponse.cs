namespace Dwellers.Authentication.Contracts.Responses
{
    public record RegisterHouseResponse(
          string Id,
          string Email,
          string Name,
          Guid InvitationToHousehold
      );
}

