using Dwellers.Household.Domain.Entities;

namespace Dwellers.Household.Application.Features.House.Commands.RegisterMemberToHouse
{
    public record RegisterMemberToHouseResult(
        DomainDwellerUser User,
        DomainDwellerHouse House
    );
}
