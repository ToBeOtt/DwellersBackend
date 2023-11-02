using Dwellers.Common.Data.Context;
using Dwellers.Common.Data.Models.DwellerServices;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices;

namespace Dwellers.Common.Persistance.OfferingsModule.Repositories.DwellerServices
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
