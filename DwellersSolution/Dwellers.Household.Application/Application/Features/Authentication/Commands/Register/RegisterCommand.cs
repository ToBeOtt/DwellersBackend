using MediatR;
using Microsoft.AspNetCore.Http;

namespace Dwellers.Household.Application.Features.Authentication.Commands.Register
{
    public record RegisterCommand(
        string Email,
        string Alias,
        string Password) : IRequest<RegisterResult>;

}
