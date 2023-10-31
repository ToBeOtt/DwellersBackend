using Dwellers.Common.DAL.Models.Household;

namespace Dwellers.Common.DAL.Services.Interfaces
{
    public interface ICommonUserServices
    {
        Task<DwellerUserEntity> GetUserForOtherServicesById(string userId);
    }
}
