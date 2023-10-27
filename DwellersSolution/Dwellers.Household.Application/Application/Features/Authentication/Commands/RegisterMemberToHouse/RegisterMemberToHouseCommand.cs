using Dwellers.Household.Application.Features.Authentication.Commands.RegisterMemberToHouse;
using MediatR;

namespace Dwellers.Household.Application.Authentication.Commands.RegisterMemberToHouse
{
    public record RegisterMemberToHouseCommand(
        Guid Invitation,
        string Email) : IRequest<RegisterMemberToHouseResult>;
    
}
