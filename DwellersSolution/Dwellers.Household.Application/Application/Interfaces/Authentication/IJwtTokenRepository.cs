using Dwellers.Household.Domain.Entities;
using System.Security.Claims;

namespace Dwellers.Household.Application.Interfaces.Authentication
{
    public interface IJwtTokenRepository
    {
        Task<string> GenerateToken(DwellerUser user, Guid houseId);
        Task<ClaimsPrincipal> ValidateToken(string token);
    }
}
