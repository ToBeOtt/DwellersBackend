using Dwellers.Common.Data.Context;
using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.EntityFrameworkCore;
using static Dwellers.DwellerCore.Domain.Entities.Dwellings.Dwelling;

namespace Dwellers.Common.Persistance.DwellerCoreModule.Repositories.Dwellings
{
    public class DwellingRepository : BaseRepository, IDwellingRepository
    {
        private readonly DwellerDbContext _context;

        public DwellingRepository(DwellerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddDwelling(Dwelling Dwelling)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDwelling(Dwelling Dwelling)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetAllDwellingNames()
        {
            return await _context.Dwellings.Select(h => h.GetName()).ToListAsync();
        }

        public async Task<Dwelling> GetDwellingById(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Dwelling> IDwellingRepository.GetDwellingByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}


//public class HouseQueryRepository : IHouseQueryRepository
//{
//    private readonly DwellerDbContext _context;

//    public HouseQueryRepository(DwellerDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<HouseEntity> GetHouseByInvite(Guid householdCode)
//    {
//        return await _context.Houses.Where(h => h.HouseholdCode == householdCode).SingleOrDefaultAsync();
//    }

//    public async Task<HouseUserEntity> GetHouseUserByUserID(string userId)
//    {
//        return await _context.HouseUsers.Where(x => x.UserId == userId).SingleOrDefaultAsync();
//    }

//    public async Task<Guid> GetHouseIdByEmail(string email)
//    {
//        var house = await _context.Houses.Include(h => h.HouseUsers)
//                               .ThenInclude(hu => hu.User)
//                            .FirstOrDefaultAsync(h => h.HouseUsers.Any(hu => hu.User.Email == email));
//        if (house != null)
//        {
//            return house.Id;
//        }
//        else return Guid.Empty;
//    }

//    public async Task<HouseEntity> GetHouseById(Guid Id)
//    {
//        return await _context.Houses.Where(x => x.Id == Id).SingleOrDefaultAsync();
//    }

//    public async Task<HouseEntity> GetHouseForOtherServicesById(Guid Id)
//    {
//        return await _context.Houses.Where(x => x.Id == Id).SingleOrDefaultAsync();
//    }

//    public async Task<List<string>> GetAllHouseNames()
//    {
//        return await _context.Houses.Select(h => h.Name).ToListAsync();
//    }
//}