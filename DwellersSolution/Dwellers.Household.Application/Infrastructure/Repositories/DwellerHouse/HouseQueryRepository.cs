using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.Household;
using Dwellers.Common.DAL.Services.Interfaces;
using Dwellers.Household.Application.Interfaces.Houses;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Household.Infrastructure.Repositories.DwellerHouse
{
    public class HouseQueryRepository : IHouseQueryRepository, ICommonHouseServices
    {
        private readonly DwellerDbContext _context;

        public HouseQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }

        public async Task<HouseEntity> GetHouseByInvite(Guid householdCode)
        {
            return await _context.Houses.Where(h => h.HouseholdCode == householdCode).SingleOrDefaultAsync();
        }

        public async Task<HouseUserEntity> GetHouseUserByUserID(string userId)
        {
           return await _context.HouseUsers.Where(x => x.UserId == userId).SingleOrDefaultAsync();
        }

        public async Task<Guid> GetHouseIdByEmail(string email)
        {
            var house = await _context.Houses.Include(h => h.HouseUsers)
                                   .ThenInclude(hu => hu.User)
                                .FirstOrDefaultAsync(h => h.HouseUsers.Any(hu => hu.User.Email == email));
            if (house != null)
            {
                return house.HouseId;
            }
            else return Guid.Empty;
        }

        public async Task<HouseEntity> GetHouseById(Guid Id)
        {
            return await _context.Houses.Where(x => x.HouseId == Id).SingleOrDefaultAsync();
        }

        public async Task<HouseEntity> GetHouseForOtherServicesById(Guid Id)
        {
            return await _context.Houses.Where(x => x.HouseId == Id).SingleOrDefaultAsync();
        }
    }
}