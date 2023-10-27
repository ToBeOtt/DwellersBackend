using Dwellers.Household.Domain.Entities;

namespace Dwellers.Household.Application.Authentication.Queries.Login
{
    public record LoginResult(
        DwellerUser User,
        string Token);
}
