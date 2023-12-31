﻿using Dwellers.Common.Data.Context;
using Dwellers.Common.Data.Models.DwellerItems;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.OfferingsModule.Repositories.DwellerItems
{
    public class DwellerItemCommandRepository : IDwellerItemCommandRepository
    {
        private readonly ILogger<DwellerItemCommandRepository> _logger;
        private readonly DwellerDbContext _context;

        public DwellerItemCommandRepository(
            ILogger<DwellerItemCommandRepository> logger,
            DwellerDbContext context)
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
        public async Task<bool> AddDwellerItem(DwellerItemEntity item)
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

        public async Task<bool> RemoveDwellerItem(DwellerItemEntity dwellerItem)
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

        public async Task<bool> RegisterItemStatus(BorrowedItemEntity borrowedItem)
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
