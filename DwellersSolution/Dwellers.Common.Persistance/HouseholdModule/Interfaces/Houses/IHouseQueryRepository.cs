using Dwellers.Common.Data.Models.Household;

namespace Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses
{
    public interface IHouseQueryRepository
    {
        Task<HouseEntity> GetHouseByInvite(Guid householdCode);
        Task<HouseEntity> GetHouseById(Guid id);
        Task<HouseUserEntity> GetHouseUserByUserID(string userId);
        Task<Guid> GetHouseIdByEmail(string userId);
        Task<List<string>> GetAllHouseNames();
    }
}
