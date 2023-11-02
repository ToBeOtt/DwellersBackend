using Dwellers.Common.Data.Models.Household;

namespace Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users
{
    public interface IUserCommandRepository
    {
        Task<bool> AddUser(DwellerUserEntity User);
        Task<bool> UpdateUser(DwellerUserEntity User);
    }
}
