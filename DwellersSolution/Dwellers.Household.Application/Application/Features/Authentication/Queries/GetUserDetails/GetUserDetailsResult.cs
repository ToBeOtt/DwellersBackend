using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Household.Application.Features.Authentication.Queries.GetUserDetails
{
    public record GetUserDetailsResult(
        Domain.Entities.DwellerUser User,
        House House);
}


