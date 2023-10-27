using Dwellers.Household.Application.Interfaces.Houses;
using Dwellers.Household.Domain.Entities.DwellerHouse;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Household.Infrastructure.Repositories.DwellerHouse
{
    public class HouseQueryRepository : IHouseQueryRepository
    {
        private readonly HouseholdDbContext _context;

        public HouseQueryRepository(HouseholdDbContext context)
        {
            _context = context;
        }

        public async Task<House> GetHouseByInvite(Guid householdCode)
        {
            return await _context.Houses.Where(h => h.HouseholdCode == householdCode).SingleOrDefaultAsync();
        }

        public async Task<HouseUser> GetHouseUserByUserID(string userId)
        {
           return await _context.HouseUsers.Where(x => x.UserId == userId).SingleOrDefaultAsync();
        }

        public async Task<House> GetHouseById(Guid houseId)
        {
            return await _context.Houses.Where(x => x.HouseId == houseId).SingleOrDefaultAsync();
        }
    }
}