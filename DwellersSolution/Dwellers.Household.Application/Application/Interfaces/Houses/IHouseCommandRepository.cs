using Dwellers.Common.DAL.Models.Household;

namespace Dwellers.Household.Application.Interfaces.Houses
{
    public interface IHouseCommandRepository
    {
        Task<bool> AddHouse(HouseEntity House);
        Task<bool> AddHouseUser(HouseUserEntity HouseUser);
    }
}
