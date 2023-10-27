using Dwellers.Household.Application.Interfaces.Household.DwellerService;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Household.Infrastructure.Repositories.Household.DwellerService
{
    public class DwellerServiceQueryRepository : IDwellerServiceQueryRepository
    {
        private readonly HouseholdDbContext _context;

        public DwellerServiceQueryRepository(HouseholdDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Domain.Entities.DwellerServices.DwellerService>> GetAllDwellerServices(Guid houseId)
        {
            throw new NotImplementedException();
            //return await _context.DwellerServices.Where(di => di.House.HouseId == houseId).ToListAsync();
        }

        public async Task<Domain.Entities.DwellerServices.DwellerService> GetDwellerService(Guid houseId)
        {
            throw new NotImplementedException();
            //return await _context.DwellerServices.Where(di => di.House.HouseId == houseId).SingleOrDefaultAsync();
        }
    }
}
