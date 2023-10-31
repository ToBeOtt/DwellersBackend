using MediatR;

namespace Dwellers.Household.Application.Features.Household.DwellerHouses.Commands.RegisterHouse
{
    public record RegisterHouseCommand(
        string Name,
        string Description,
        string Email) : IRequest<RegisterHouseResult>;

}
