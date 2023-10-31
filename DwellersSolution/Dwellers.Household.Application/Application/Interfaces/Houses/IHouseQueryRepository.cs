using Dwellers.Common.DAL.Models.Household;

namespace Dwellers.Household.Application.Interfaces.Houses
{
    public interface IHouseQueryRepository
    {
        Task<HouseEntity> GetHouseByInvite(Guid householdCode);
        Task<HouseEntity> GetHouseById(Guid id);
        Task<HouseUserEntity> GetHouseUserByUserID(string userId);
        Task<Guid> GetHouseIdByEmail(string userId);
    }
}
