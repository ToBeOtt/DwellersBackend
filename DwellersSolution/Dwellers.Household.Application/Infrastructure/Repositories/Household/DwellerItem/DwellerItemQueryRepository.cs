using Dwellers.Household.Application.Interfaces.Household.DwellerItems;
using Dwellers.Household.Domain.Entities.DwellerItems;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Dwellers.Household.Infrastructure.Repositories.Household.DwellerItem
{
    public class DwellerItemQueryRepository : IDwellerItemQueryRepository
    {
        private readonly HouseholdDbContext _context;

        public DwellerItemQueryRepository(HouseholdDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Domain.Entities.DwellerItems.DwellerItem>> GetAllDwellerItems(Guid houseId)
        {
            return await _context.DwellerItems
                                .Include(di => di.BorrowedItems)
                                .Where(di => di.BorrowedItems.Any(bi => bi.HouseId == houseId))
                                .ToListAsync();
        }

        public async Task<Domain.Entities.DwellerItems.DwellerItem> GetDwellerItem(Guid ItemId)
        {
            return await _context.DwellerItems
                            .Include(di => di.BorrowedItems)
                            .Where(di => di.Id == ItemId)
                            .SingleOrDefaultAsync();
        }
    }
}
