using Dwellers.Household.Application.Interfaces.Household.DwellerService;
using Dwellers.Household.Domain.Entities.DwellerServices;
using Dwellers.Household.Infrastructure.Data;
using Dwellers.Household.Infrastructure.Repositories.Household.DwellerItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Infrastructure.Repositories.Household.DwellerService
{
    internal class DwellerServiceCommandRepository : IDwellerServiceCommandRepository
    {
        private readonly ILogger<DwellerServiceCommandRepository> _logger;
        private readonly HouseholdDbContext _context;

        public DwellerServiceCommandRepository(
            ILogger<DwellerServiceCommandRepository> logger,
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
        public async Task<bool> AddDwellerService(Domain.Entities.DwellerServices.DwellerService service)
        {
            await _context.DwellerServices.AddAsync(service);
            int result = await SaveActions();
            return result > 0;
        }

        public Task<bool> RegisterProvidedService(ProvidedService service)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveDwellerService(Domain.Entities.DwellerServices.DwellerService service)
        {
            throw new NotImplementedException();
        }
    }
}
