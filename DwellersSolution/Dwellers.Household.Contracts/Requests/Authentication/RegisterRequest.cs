using Microsoft.AspNetCore.Http;

namespace Dwellers.Household.Contracts.Requests
{
    public record RegisterRequest(
        string Email,
        string Alias,
        string Password);
}
