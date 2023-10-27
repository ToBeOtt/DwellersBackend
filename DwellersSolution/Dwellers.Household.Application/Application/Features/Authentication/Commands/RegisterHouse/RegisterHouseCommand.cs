using MediatR;

namespace Dwellers.Household.Application.Authentication.Commands.RegisterHouse
{
    public record RegisterHouseCommand(
        string Name,
        string Description,
        string Email) : IRequest<RegisterHouseResult>;

}
