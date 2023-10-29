using Dwellers.Authentication.Domain;
using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Authentication.Contracts.Responses
{
    public record GetUserDetailsResponse(
         DwellerUser User,
         House House
     );
}
