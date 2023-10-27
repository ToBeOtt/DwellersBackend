namespace Dwellers.Household.Contracts.Responses.Authentication
{
    public record RegisterHouseResponse(
          string Id,
          string Email,
          string Name,
          Guid InvitationToHousehold
      );
}

