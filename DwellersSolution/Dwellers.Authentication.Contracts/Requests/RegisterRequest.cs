using Microsoft.AspNetCore.Http;

namespace Dwellers.Authentication.Contracts.Requests
{
    public record RegisterRequest(
        string Email,
        string Alias,
        string Password);
}
