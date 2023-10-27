using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Household.Application.Features.Authentication.Commands.RegisterMemberToHouse
{
    public record RegisterMemberToHouseResult(
        Domain.Entities.DwellerUser User,
        House House
    );
}
