using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Household.Contracts.Responses.Authentication
{
    public record GetUserDetailsResponse(
         Domain.Entities.DwellerUser User,
         House House
     );
}
