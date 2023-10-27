using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Household.Application.Interfaces.Houses
{
    public interface IHouseQueryRepository
    {
        Task<House> GetHouseByInvite(Guid householdCode);
        Task<HouseUser> GetHouseUserByUserID(string userId);
        Task<House> GetHouseById(Guid houseId);
    }
}
