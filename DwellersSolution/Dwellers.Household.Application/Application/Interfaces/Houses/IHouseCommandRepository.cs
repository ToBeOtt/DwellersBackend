using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Household.Application.Interfaces.Houses
{
    public interface IHouseCommandRepository
    {
        Task<bool> AddHouse(House House);
        Task<bool> AddHouseUser(HouseUser HouseUser);
    }
}
