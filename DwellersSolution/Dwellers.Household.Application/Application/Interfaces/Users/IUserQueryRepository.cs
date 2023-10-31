using Dwellers.Common.DAL.Models.Household;

namespace Dwellers.Household.Application.Interfaces.Users
{
    public interface IUserQueryRepository
    {
        Task<DwellerUserEntity> GetUserByEmail(string email);
        Task<bool> CheckLoginCredentials(string username, string password);
        Task<DwellerUserEntity> GetUserById(string userId);
    }
}
