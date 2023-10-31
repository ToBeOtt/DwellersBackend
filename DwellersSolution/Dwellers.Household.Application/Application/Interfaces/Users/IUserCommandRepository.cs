using Dwellers.Common.DAL.Models.Household;
using Dwellers.Household.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Dwellers.Household.Application.Interfaces.Users
{
    public interface IUserCommandRepository
    {
        Task<bool> AddUser(DwellerUserEntity User);
        Task<bool> UpdateUser(DwellerUserEntity User);
        


    }
}
