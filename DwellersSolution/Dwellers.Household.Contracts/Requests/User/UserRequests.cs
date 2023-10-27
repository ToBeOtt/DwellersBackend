using Microsoft.AspNetCore.Http;

namespace Dwellers.Household.Contracts.Requests.User
{
    public record UpdateUserRequest(
        IFormFile ProfilePhoto);
}
