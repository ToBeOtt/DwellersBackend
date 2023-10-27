using MediatR;

namespace Dwellers.Household.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<LoginResult>;
}
