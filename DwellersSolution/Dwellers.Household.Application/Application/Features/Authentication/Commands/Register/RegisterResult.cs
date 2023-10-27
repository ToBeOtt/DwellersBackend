using Dwellers.Household.Domain.Entities;

namespace Dwellers.Household.Application.Features.Authentication.Commands.Register
{
    public record RegisterResult(
        Domain.Entities.DwellerUser User
    );




}
