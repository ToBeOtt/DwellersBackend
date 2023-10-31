using Dwellers.Authentication.Domain;
using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Authentication.Contracts.Responses
{
    public record GetUserDetailsResponse(
         DbUser User,
         DwellerHouse House
     );
}
