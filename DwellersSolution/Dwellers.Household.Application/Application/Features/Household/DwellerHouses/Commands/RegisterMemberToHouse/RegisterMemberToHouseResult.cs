using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Household.Application.Features.Household.DwellerHouses.Commands.RegisterMemberToHouse
{
    public record RegisterMemberToHouseResult(
        Domain.Entities.DomainDwellerUser User,
        DwellerHouse House
    );
}
