using Dwellers.Common.Data.Context;
using Dwellers.Common.Data.Models.Household;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;

namespace Dwellers.Common.Persistance.HouseholdModule.Repositories.Houses
{
    public class HouseCommandRepository : IHouseCommandRepository
    {
        private readonly DwellerDbContext _context;

        public HouseCommandRepository(DwellerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddHouse(HouseEntity house)
        {
            await _context.Houses.AddAsync(house);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddHouseUser(HouseUserEntity houseUser)
        {
            await _context.HouseUsers.AddAsync(houseUser);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
