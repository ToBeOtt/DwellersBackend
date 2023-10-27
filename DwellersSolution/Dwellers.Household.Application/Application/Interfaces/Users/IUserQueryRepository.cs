using Dwellers.Household.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Dwellers.Household.Application.Interfaces.Users
{
    public interface IUserQueryRepository
    {
        Task<DwellerUser?> GetUserByEmail(string email);
        Task<DwellerUser?> GetUserById(string id);
        Task<SignInResult> CheckLoginCredentials(string username, string password);
    }
}
