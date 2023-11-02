using Dwellers.Common.Data.Models.Household;

namespace Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses
{
    public interface IHouseCommandRepository
    {
        Task<bool> AddHouse(HouseEntity House);
        Task<bool> AddHouseUser(HouseUserEntity HouseUser);
    }
}
