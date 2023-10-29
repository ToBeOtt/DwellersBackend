using Dwellers.Household.Domain.Entities.DwellerHouse;

namespace Dwellers.Household.Contracts.Interfaces
{
    public interface IHouseHold
    {
        ICollection<HouseUser> HouseUsers { get; }
    }
}
