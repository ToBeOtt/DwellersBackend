using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.DwellerItems;
using Dwellers.Offerings.Application.Interfaces.DwellerItems;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Offerings.Repositories.DwellerItems
{
    public class DwellerItemQueryRepository : IDwellerItemQueryRepository
    {
        private readonly DwellerDbContext _context;

        public DwellerItemQueryRepository(DwellerDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<DwellerItemEntity>> GetAllDwellerItems(Guid houseId)
        {
            return await _context.DwellerItems
                                .Include(di => di.BorrowedItems)
                                .Where(di => di.BorrowedItems.Any(bi => bi.HouseId == houseId))
                                .ToListAsync();
        }

        public async Task<DwellerItemEntity> GetDwellerItem(Guid ItemId)
        {
            return await _context.DwellerItems
                            .Include(di => di.BorrowedItems)
                            .Where(di => di.Id == ItemId)
                            .SingleOrDefaultAsync();
        }
    }
}
