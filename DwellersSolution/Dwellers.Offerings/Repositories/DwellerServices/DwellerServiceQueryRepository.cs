using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.DwellerServices;
using Dwellers.Offerings.Application.Interfaces.DwellerServices;

namespace Dwellers.Offerings.Repositories.DwellerServices
{
    public class DwellerServiceQueryRepository : IDwellerServiceQueryRepository
    {
        private readonly DwellerDbContext _context;

        public DwellerServiceQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<DwellerServiceEntity>> GetAllDwellerServices(Guid houseId)
        {
            throw new NotImplementedException();
            //return await _context.DwellerServices.Where(di => di.House.HouseId == houseId).ToListAsync();
        }

        public async Task<DwellerServiceEntity> GetDwellerService(Guid houseId)
        {
            throw new NotImplementedException();
            //return await _context.DwellerServices.Where(di => di.House.HouseId == houseId).SingleOrDefaultAsync();
        }
    }
}
