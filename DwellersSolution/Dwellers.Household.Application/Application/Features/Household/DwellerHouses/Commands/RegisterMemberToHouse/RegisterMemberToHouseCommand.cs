using MediatR;

namespace Dwellers.Household.Application.Features.Household.DwellerHouses.Commands.RegisterMemberToHouse
{
    public record RegisterMemberToHouseCommand(
        Guid Invitation,
        string Email) : IRequest<RegisterMemberToHouseResult>;

}
