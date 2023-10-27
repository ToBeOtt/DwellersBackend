using Dwellers.Household.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Dwellers.Household.Application.Interfaces.Users
{
    public interface IUserCommandRepository
    {
        Task<IdentityResult> AddUser(DwellerUser User, string password);
        Task<bool> UpdateUser(DwellerUser User);
        


    }
}
