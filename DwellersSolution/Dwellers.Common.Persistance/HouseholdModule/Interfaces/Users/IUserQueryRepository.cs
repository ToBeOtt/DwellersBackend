using Dwellers.Common.Data.Models.Household;

namespace Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users
{
    public interface IUserQueryRepository
    {
        Task<DwellerUserEntity> GetUserByEmail(string email);
        Task<bool> CheckLoginCredentials(string username, string password);
        Task<DwellerUserEntity> GetUserById(string userId);
    }
}
