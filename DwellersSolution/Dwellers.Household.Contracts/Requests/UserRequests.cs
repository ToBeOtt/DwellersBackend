using Microsoft.AspNetCore.Http;

namespace Dwellers.Household.Contracts.Requests
{
    public record UpdateUserRequest(
        IFormFile ProfilePhoto);
    public record FetchUserDetailsRequest(
        string UserId);
}

