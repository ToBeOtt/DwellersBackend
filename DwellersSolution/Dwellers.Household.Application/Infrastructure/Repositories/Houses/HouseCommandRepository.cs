using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.Household;
using Dwellers.Household.Application.Interfaces.Houses;

namespace Dwellers.Household.Infrastructure.Repositories.Houses
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
