using Dwellers.Household.Application.Interfaces.Household.DwellerItems;
using Dwellers.Household.Domain.Entities.DwellerEvents;
using Dwellers.Household.Domain.Entities.DwellerItems;
using Dwellers.Household.Domain.Entities.Notes;
using Dwellers.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Infrastructure.Repositories.Household.DwellerItem
{
    public class DwellerItemCommandRepository : IDwellerItemCommandRepository
    {
        private readonly ILogger<DwellerItemCommandRepository> _logger;
        private readonly HouseholdDbContext _context;

        public DwellerItemCommandRepository(
            ILogger<DwellerItemCommandRepository> logger,
            HouseholdDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        private async Task<int> SaveActions()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
        }
        public async Task<bool> AddDwellerItem(Domain.Entities.DwellerItems.DwellerItem item)
        {
            try
            {
                await _context.DwellerItems.AddAsync(item);
                int result = await SaveActions();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding DwellerItem: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> RemoveDwellerItem (Domain.Entities.DwellerItems.DwellerItem dwellerItem)
        {
            try
            {
                _context.DwellerItems.Remove(dwellerItem);
                int result = await SaveActions();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while removing DwellerItem: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> RegisterItemStatus(BorrowedItem borrowedItem)
        {
            try
            {
                await _context.BorrowedItems.AddAsync(borrowedItem);
                int result = await SaveActions();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while registering item-status: " + ex.Message);
                return false;
            }
            
        }

    }
}
